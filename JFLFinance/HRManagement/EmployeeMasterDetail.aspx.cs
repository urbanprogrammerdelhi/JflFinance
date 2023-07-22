// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 02-17-2014
// ***********************************************************************
// <copyright file="EmployeeMasterDetail.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Class HRManagement_EmployeeMasterDetail
/// </summary>
public partial class HRManagement_EmployeeMasterDetail : BasePage//System.Web.UI.Page
{
    /// <summary>
    /// The URL referrer
    /// </summary>
    static string urlReferrer = String.Empty;
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
    protected string SessionUserID
    {
        get
        {
            try
            {
                if (BaseUserInformation.UserId != string.Empty)
                { return BaseUserInformation.UserId; }
                System.Web.HttpContext.Current.Response.Redirect("../default.aspx");
                return string.Empty;
            }
            catch (Exception ex)
            { throw new Exception("Session has expired! Login again", ex); }
        }
    }
    #region Page function
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //  Page.Culture = "en-GB";
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                urlReferrer = Request.UrlReferrer.ToString();
            }
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EmployeeDetail + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                btnUploadDownload.Attributes.Add("OnClick", "javascript:OpenEmployeeDocumnetUpload()");

                string strStatus = Request.QueryString["strStatus"];
                if (Request.QueryString["PageStatus"] != null)
                {
                    btnBack.Visible = false;
                    strStatus = Resources.Resource.Next;

                }
                if (Request.QueryString["strEmployeeNumber"] != null)
                {
                    lblEmployeeNumberViewEmployeejobDetail.Text = Request.QueryString["strEmployeeNumber"].ToString();

                }
                if (Request.QueryString["DOB"] != null)
                {
                    lblDOB.Value= Request.QueryString["DOB"].ToString();

                }
                FillgvTraining(lblEmployeeNumberViewEmployeejobDetail.Text);
                FillgvQualification(lblEmployeeNumberViewEmployeejobDetail.Text);
                FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
                FillgvSkills(lblEmployeeNumberViewEmployeejobDetail.Text);
                FillddlCompany();
                FillddlHrLocation();
                FillgvEmployeeItemIssuing();
                FillgvEmployeeReferenceDetail();
                FillgvEmployeeEducationDetail();
                FillgvEmployeeExperience();
                FillgvEmpReferredBy();
                FillPFnESI();
                ValidateFieldsPFnESI();
                if (strStatus == Resources.Resource.AddNew)
                {
                    FillEmployeeDetail(lblEmployeeNumberViewEmployeejobDetail.Text);//TO FILL DETAILS IN EMPLOYEE DETAIL SECTION
                }
                if (strStatus == Resources.Resource.Next)
                {
                    FillEmployeeDetail(lblEmployeeNumberViewEmployeejobDetail.Text);//TO FILL DETAILS IN EMPLOYEE DETAIL SECTION
                }

                if (Request.QueryString["strStatus"] == Resources.Resource.Update)
                {
                    FillEmployeeDetail(lblEmployeeNumberViewEmployeejobDetail.Text);//TO FILL DETAILS IN EMPLOYEE DETAIL SECTION
                }

                #region to Show the EmployeeImage

                string path = "../DocumentUpload/EmployeeImages/";
                string FileName = path + lblEmployeeNumberViewEmployeejobDetail.Text + ".jpg";
                //string DefaultFileName = path + "EmpNoImage" + ".jpg";
                string DefaultFileName = path + "DefaultEmployeeImage" + ".jpg";

                string ServerLocalPath = Server.MapPath(path);
                string ServerLocalFileName = ServerLocalPath + lblEmployeeNumberViewEmployeejobDetail.Text + ".jpg";
                //string ServerLocalDefaultFileName = ServerLocalPath + "EmpNoImage" + ".jpg";
                string ServerLocalDefaultFileName = ServerLocalPath + "DefaultEmployeeImage" + ".jpg";

                if (File.Exists(ServerLocalFileName))
                {
                    ImageBox.ImageUrl = FileName;
                }
                else if (File.Exists(ServerLocalDefaultFileName))
                {
                    ImageBox.ImageUrl = DefaultFileName;
                }

                #endregion

                if (Request.QueryString["PageStatus"] != null)
                {
                    btnBack.Visible = false;

                }
            }
        }
    }
    #endregion

    #region Function Related to fill Employee Detail
    /// <summary>
    /// Fills the employee detail.
    /// </summary>
    /// <param name="EmployeeNumber">The employee number.</param>
    private void FillEmployeeDetail(String EmployeeNumber)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objHrManagement.EmployeeDetailUpdate(EmployeeNumber, BaseLocationAutoID);
        lblName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + ds.Tables[0].Rows[0]["LastName"].ToString();
        lblDateOfJoining.Text = DateFormat(ds.Tables[0].Rows[0]["DateOfJoining"].ToString());
        lblDesignationView.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();
        lblCategoryView.Text = ds.Tables[0].Rows[0]["CategoryDesc"].ToString();
        lblJobClassView.Text = ds.Tables[0].Rows[0]["JobClassDesc"].ToString();
        lblJobTypeView.Text = ds.Tables[0].Rows[0]["JobTypeDesc"].ToString();
    }
    #endregion

    #region Function Related to fill Training Grid

    /// <summary>
    /// Fillgvs the training.
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    private void FillgvTraining(string strEmployeeNumber)
    {
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsTraining = new DataSet();
        DataTable dtTraining = new DataTable();
        int dtflag;
        dtflag = 1;
        dsTraining = objHrManagement.EmployeeTrainingGet(BaseCompanyCode, strEmployeeNumber);
        dtTraining = dsTraining.Tables[0];
        if (dtTraining.Rows.Count == 0)
        {
            dtflag = 0;
            dtTraining.Rows.Add(dtTraining.NewRow());
        }
        gvTraining.DataSource = dtTraining;
        gvTraining.DataBind();

        if (dtflag == 0)
        {
            gvTraining.Rows[0].Visible = false;
        }
    }

    /// <summary>
    /// Handles the RowCommand1 event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DropDownList ddlNewTrainingDesc = (DropDownList)gvTraining.FooterRow.FindControl("ddlNewTrainingDesc");
        TextBox txtNewDuration = (TextBox)gvTraining.FooterRow.FindControl("txtNewDuration");

        TextBox txtNewTrainingDate = (TextBox)gvTraining.FooterRow.FindControl("txtNewTrainingDate");
        TextBox txtNewValidTillDate = (TextBox)gvTraining.FooterRow.FindControl("txtNewValidTillDate");

        if (e.CommandName.Equals("AddNew"))
        {
            if (lblEmployeeNumberViewEmployeejobDetail.Text != "")
            {

                if (txtNewTrainingDate.Text != "")
                {
                    if (txtNewValidTillDate.Text != "")
                    {
                        if (DateTime.Parse(txtNewTrainingDate.Text) > DateTime.Parse(txtNewValidTillDate.Text))
                        {
                            lblErrorMsgTraining.Text = "Training Date Cannot Be Greater Than Valid Till Date";
                            ToolkitScriptManager1.SetFocus(txtNewTrainingDate);
                            return;
                        }
                    }
                    else
                    {
                        lblErrorMsgTraining.Text = "Training Valid Till Date Cannot Be Blank";
                        ToolkitScriptManager1.SetFocus(txtNewValidTillDate);
                        return;
                    }
                }
                else
                {
                    lblErrorMsgTraining.Text = "Training Date Cannot Be Blank";
                    ToolkitScriptManager1.SetFocus(txtNewTrainingDate);
                    return;
                }


                ds = objHrManagement.EmployeeTrainingInsert(lblEmployeeNumberViewEmployeejobDetail.Text, ddlNewTrainingDesc.SelectedValue.ToString(), txtNewDuration.Text, DateTime.Parse(txtNewTrainingDate.Text), DateTime.Parse(txtNewValidTillDate.Text), BaseUserID, BaseCompanyCode);
                if (gvTraining.Rows.Count.Equals(gvTraining.PageSize))
                {
                    gvTraining.PageIndex = gvTraining.PageCount + 1;
                }
                gvTraining.EditIndex = -1;
                FillgvTraining(lblEmployeeNumberViewEmployeejobDetail.Text);
                DisplayMessage(lblErrorMsgTraining, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                Response.Redirect("../HRManagement/EmployeeDetail.aspx");
            }

        }
        if (e.CommandName.Equals("Reset"))
        {
            txtNewDuration.Text = "";
            txtNewTrainingDate.Text = "";
            txtNewValidTillDate.Text = "";
        }

    }

    /// <summary>
    /// Handles the RowDataBound1 event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvTraining.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsModifyAccess == false)
            {
                ImageButton IBEditTran = (ImageButton)e.Row.FindControl("IBEditTran");

                if (IBEditTran != null)
                {
                    IBEditTran.Visible = false;
                }
            }
            else
            {
                ImageButton ImgbtnUpdateTran = (ImageButton)e.Row.FindControl("ImgbtnUpdateTran");//ImageButton1 is Update link name
                if (ImgbtnUpdateTran != null)
                {
                    ImgbtnUpdateTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgTraining.ClientID.ToString() + "');";
                }

                TextBox txtDuration = (TextBox)e.Row.FindControl("txtDuration");
                if (txtDuration != null)
                {
                    txtDuration.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtDuration.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }

            }
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteTran = (ImageButton)e.Row.FindControl("IBDeleteTran");
                if (IBDeleteTran != null)
                {
                    IBDeleteTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgTraining.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvTraining.ShowFooter = false;
            }
            else
            {
                DropDownList ddlNewTrainingDesc = (DropDownList)e.Row.FindControl("ddlNewTrainingDesc");

                TextBox txtNewTrainingDate = (TextBox)e.Row.FindControl("txtNewTrainingDate");
                TextBox txtNewValidTillDate = (TextBox)e.Row.FindControl("txtNewValidTillDate");

                TextBox txtNewDuration = (TextBox)e.Row.FindControl("txtNewDuration");
                if (txtNewDuration != null)
                {
                    txtNewDuration.Attributes["onKeyUp"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                    txtNewDuration.Attributes["onblur"] = "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");";
                }


                ImageButton ImgbtnAddTran = (ImageButton)e.Row.FindControl("ImgbtnAddTran");
                if (ddlNewTrainingDesc != null)
                {
                    ddlNewTrainingDesc.DataSource = objMastersManagement.TrainingMasterGetAll(BaseCompanyCode).Tables[0];
                    ddlNewTrainingDesc.DataTextField = "TrainingDesc";
                    ddlNewTrainingDesc.DataValueField = "TrainingCode";
                    ddlNewTrainingDesc.DataBind();
                    if (ddlNewTrainingDesc.SelectedValue.ToString() == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoData;
                        li.Value = "0";
                        ddlNewTrainingDesc.Items.Add(li);
                        ImgbtnAddTran.Enabled = false;
                    }
                }

                if (ImgbtnAddTran != null)
                {
                    ImgbtnAddTran.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgTraining.ClientID.ToString() + "');";
                }
            }
        }

    }

    /// <summary>
    /// Handles the RowCancelingEdit event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvTraining.EditIndex = -1;
        FillgvTraining(lblEmployeeNumberViewEmployeejobDetail.Text);
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objHrManagement.EmployeeTrainingDelete(gvTraining.DataKeys[e.RowIndex].Values[0].ToString(), gvTraining.DataKeys[e.RowIndex].Values[1].ToString(), DateTime.Parse(gvTraining.DataKeys[e.RowIndex].Values[2].ToString()), BaseCompanyCode);
        FillgvTraining(lblEmployeeNumberViewEmployeejobDetail.Text);
        DisplayMessage(lblErrorMsgTraining, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        TextBox txtDuration = (TextBox)gvTraining.Rows[e.RowIndex].FindControl("txtDuration");
        Label lblTrainingCode = (Label)gvTraining.Rows[e.RowIndex].FindControl("lblTrainingCode");

        Label txtEditTrainingDate = (Label)gvTraining.Rows[e.RowIndex].FindControl("txtEditTrainingDate");
        TextBox txtEditValidTillDate = (TextBox)gvTraining.Rows[e.RowIndex].FindControl("txtEditValidTillDate");

        ds = objHrManagement.EmployeeTrainingUpdate(lblEmployeeNumberViewEmployeejobDetail.Text, lblTrainingCode.Text, txtDuration.Text, DateTime.Parse(txtEditTrainingDate.Text), DateTime.Parse(txtEditValidTillDate.Text), BaseUserID, BaseCompanyCode);
        gvTraining.EditIndex = -1;
        DisplayMessage(lblErrorMsgTraining, ds.Tables[0].Rows[0]["MessageID"].ToString());
        FillgvTraining(lblEmployeeNumberViewEmployeejobDetail.Text);
    }

    /// <summary>
    /// Handles the PageIndexChanging event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTraining.PageIndex = e.NewPageIndex;
        FillgvTraining(lblEmployeeNumberViewEmployeejobDetail.Text);
    }

    /// <summary>
    /// Handles the RowEditing1 event of the gvTraining control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvTraining_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        gvTraining.EditIndex = e.NewEditIndex;
        FillgvTraining(lblEmployeeNumberViewEmployeejobDetail.Text);
    }

    /// <summary>
    /// Handles the TextChanged event of the txtNewTrainingDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewTrainingDate_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtNewTrainingDate = (TextBox)gvTraining.FooterRow.FindControl("txtNewTrainingDate");
        TextBox txtNewValidTillDate = (TextBox)gvTraining.FooterRow.FindControl("txtNewValidTillDate");
        ConvertStringToDateFormat(txtNewTrainingDate);

        DataSet ds = new DataSet();
        BL.HRManagement objTrainingValidDate = new BL.HRManagement();
        DropDownList ddlNewTrainingDesc = (DropDownList)gvTraining.FooterRow.FindControl("ddlNewTrainingDesc");
        ds = objTrainingValidDate.TrainingValidToDateGet(BaseCompanyCode, ddlNewTrainingDesc.SelectedValue.ToString(), DateTime.Parse(txtNewTrainingDate.Text));

        if (int.Parse(ds.Tables[0].Rows[0]["flag"].ToString()) == 1)
        {
            txtNewValidTillDate.Text = DateFormat(ds.Tables[0].Rows[0]["TrainingToDate"].ToString());
        }
        else
        {
            txtNewValidTillDate.Text = "";

            ToolkitScriptManager1.SetFocus(txtNewValidTillDate);
            lblErrorMsgTraining.Text = Resources.Resource.InvalidateFromDate;
        }

        ToolkitScriptManager1.SetFocus(txtNewValidTillDate);
    }

    /// <summary>
    /// Handles the TextChanged event of the txtNewValidTillDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtNewValidTillDate_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox txtNewValidTillDate = (TextBox)gvTraining.FooterRow.FindControl("txtNewValidTillDate");
        ConvertStringToDateFormat(txtNewValidTillDate);
    }

    /// <summary>
    /// Handles the TextChanged event of the txtEditValidTillDate control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void txtEditValidTillDate_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager ToolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        TextBox objTextBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)objTextBox.NamingContainer;
        TextBox txtEditValidTillDate = (TextBox)gvTraining.Rows[row.RowIndex].FindControl("txtEditValidTillDate");
        ConvertStringToDateFormat(txtEditValidTillDate);
    }

    /// <summary>
    /// Converts the string to date format.
    /// </summary>
    /// <param name="txtDate">The TXT date.</param>
    private void ConvertStringToDateFormat(TextBox txtDate)
    {
        string date;
        txtDate.BackColor = System.Drawing.Color.Empty;
        BL.Common objCommon = new BL.Common();
        System.Web.UI.ScriptManager ToolkitScriptManager2 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        if (objCommon.IsValidDate(txtDate.Text))
        {
            txtDate.Text = DateTime.Parse(txtDate.Text).ToString("dd-MMM-yyyy");
        }
        else
        {
            date = objCommon.ConvertToDate(txtDate.Text);
            if (date == "1")
            {
                lblErrorMsgTraining.Text = "Year not in correct format ";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "2")
            {
                lblErrorMsgTraining.Text = "Month not in correct format";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "3")
            {
                lblErrorMsgTraining.Text = "Day not in correct format";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "4")
            {
                lblErrorMsgTraining.Text = "Not a leap year";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "5")
            {
                lblErrorMsgTraining.Text = "Number of days not correct";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else if (date == "6")
            {
                lblErrorMsgTraining.Text = "Date not in correct format";
                txtDate.Text = txtDate.Text;
                ToolkitScriptManager2.SetFocus(txtDate);
                txtDate.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                txtDate.Text = date;
                txtDate.BackColor = System.Drawing.Color.Empty;
            }
        }
    }

    #endregion

    #region Function To Fill Qualification Grid

    /// <summary>
    /// Fillgvs the qualification.
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    private void FillgvQualification(string strEmployeeNumber)
    {

        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsQualification = new DataSet();
        DataTable dtQualification = new DataTable();
        int dtflag;
        dtflag = 1;
        dsQualification = objHrManagement.EmployeeQualificationGet(BaseCompanyCode, strEmployeeNumber);
        dtQualification = dsQualification.Tables[0];
        if (dtQualification.Rows.Count == 0)
        {
            dtflag = 0;
            dtQualification.Rows.Add(dtQualification.NewRow());
        }
        gvQualification.DataSource = dtQualification;
        gvQualification.DataBind();

        if (dtflag == 0)
        {
            gvQualification.Rows[0].Visible = false;
        }
    }

    #endregion

    #region Function To Fill Language Grid

    /// <summary>
    /// Fillgvs the language.
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    private void FillgvLanguage(string strEmployeeNumber)
    {
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsLanguage = new DataSet();
        DataTable dtLanguage = new DataTable();
        int dtflag;
        dtflag = 1;
        dsLanguage = objHrManagement.EmployeeLanguageGet(BaseCompanyCode, strEmployeeNumber);
        dtLanguage = dsLanguage.Tables[0];
        if (dtLanguage.Rows.Count == 0)
        {
            dtflag = 0;
            dtLanguage.Rows.Add(dtLanguage.NewRow());
        }
        gvlanguage.DataSource = dtLanguage;
        gvlanguage.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvlanguage.Rows[0].Visible = false;
        }

    }

    #endregion

    #region Function Related to Employee Qualification Grid

    /// <summary>
    /// Handles the RowCommand event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DropDownList ddlNewQualificationDesc = (DropDownList)gvQualification.FooterRow.FindControl("ddlNewQualificationDesc");
        if (e.CommandName.Equals("AddNewQualification"))
        {
            if (lblEmployeeNumberViewEmployeejobDetail.Text != "")
            {
                ds = objHrManagement.EmployeeQualificationInsert(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, ddlNewQualificationDesc.SelectedValue.ToString(), BaseUserID);
                if (gvQualification.Rows.Count.Equals(gvQualification.PageSize))
                {
                    gvQualification.PageIndex = gvQualification.PageCount + 1;
                }
                FillgvQualification(lblEmployeeNumberViewEmployeejobDetail.Text);
                DisplayMessage(lblErrorMsgQualification, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                Response.Redirect("../HRManagement/EmployeeDetail.aspx");
            }
        }
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvQualification.EditIndex = -1;
        FillgvQualification(lblEmployeeNumberViewEmployeejobDetail.Text);
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        ds = objHrManagement.EmployeeQualificationDelete(BaseCompanyCode, gvQualification.DataKeys[e.RowIndex].Values["EmployeeNumber"].ToString(), gvQualification.DataKeys[e.RowIndex].Values["QualificationCode"].ToString());
        FillgvQualification(lblEmployeeNumberViewEmployeejobDetail.Text);
        DisplayMessage(lblErrorMsgQualification, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvQualification.PageIndex = e.NewPageIndex;
        FillgvQualification(lblEmployeeNumberViewEmployeejobDetail.Text);
    }
    /// <summary>
    /// Handles the RowDataBound event of the gvQualification control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvQualification_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvQualification.Columns[2].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteQual = (ImageButton)e.Row.FindControl("IBDeleteQual");
                if (IBDeleteQual != null)
                {
                    IBDeleteQual.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteQual = (ImageButton)e.Row.FindControl("IBDeleteQual");
                if (IBDeleteQual != null)
                {
                    IBDeleteQual.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgQualification.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvQualification.ShowFooter = false;
            }
            else
            {
                DropDownList ddlNewQualificationDesc = (DropDownList)e.Row.FindControl("ddlNewQualificationDesc");
                ImageButton ImgbtnAddQual = (ImageButton)e.Row.FindControl("ImgbtnAddQual");
                if (ddlNewQualificationDesc != null)
                {
                    ddlNewQualificationDesc.DataSource = objMastersManagement.QualificationMasterGetAll();
                    ddlNewQualificationDesc.DataTextField = "QualificationDesc";
                    ddlNewQualificationDesc.DataValueField = "QualificationCode";
                    ddlNewQualificationDesc.DataBind();
                    if (ddlNewQualificationDesc.SelectedValue.ToString() == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoData;
                        li.Value = "0";
                        ddlNewQualificationDesc.Items.Add(li);
                        ImgbtnAddQual.Enabled = false;
                    }
                }

                if (ImgbtnAddQual != null)
                {
                    ImgbtnAddQual.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgQualification.ClientID.ToString() + "');";
                }
            }
        }
    }
    #endregion

    #region Function Related to Employee Language Grid

    /// <summary>
    /// Handles the RowDataBound event of the gvlanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvlanguage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvlanguage.Columns[3].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton IBDeleteLang = (ImageButton)e.Row.FindControl("IBDeleteLang");
            ImageButton imgbtnUpdateLang = (ImageButton)e.Row.FindControl("imgbtnUpdateLang");
            if (IsModifyAccess == false)
            {
                ImageButton IBEditLang = (ImageButton)e.Row.FindControl("IBEditLang");
                if (IBEditLang != null)
                {
                    IBEditLang.Visible = false;
                }

            }
            else
            {
                if (imgbtnUpdateLang != null)
                {
                    imgbtnUpdateLang.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgLanguage.ClientID.ToString() + "');";
                }
            }
            if (IsDeleteAccess == false)
            {
                IBDeleteLang.Visible = false;
            }
            else
            {
                if (IBDeleteLang != null)
                {
                    IBDeleteLang.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgLanguage.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvlanguage.ShowFooter = false;
            }
            else
            {
                DropDownList ddlNewLanguageDesc = (DropDownList)e.Row.FindControl("ddlNewLanguageDesc");
                ImageButton ImgbtnAddNewlang = (ImageButton)e.Row.FindControl("ImgbtnAddNewlang");
                if (ddlNewLanguageDesc != null)
                {
                    ddlNewLanguageDesc.DataSource = objMastersManagement.LanguageMasterGetAll();
                    ddlNewLanguageDesc.DataTextField = "LanguageDesc";
                    ddlNewLanguageDesc.DataValueField = "LanguageCode";
                    ddlNewLanguageDesc.DataBind();
                    if (ddlNewLanguageDesc.SelectedValue.ToString() == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoData;
                        li.Value = "0";
                        ddlNewLanguageDesc.Items.Add(li);
                        ImgbtnAddNewlang.Enabled = false;
                    }

                }

                if (ImgbtnAddNewlang != null)
                {
                    ImgbtnAddNewlang.Attributes["onclick"] = "javascript:Timerf('" + lblErrorMsgLanguage.ClientID.ToString() + "');";
                }
            }
        }

    }
    /// <summary>
    /// Handles the RowCommand event of the gvlanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvlanguage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DropDownList ddlNewLanguageDesc = (DropDownList)gvlanguage.FooterRow.FindControl("ddlNewLanguageDesc");
        DropDownList ddlNewProficiency = (DropDownList)gvlanguage.FooterRow.FindControl("ddlNewProficiency");
        CheckBox cbNewMotherTongue = (CheckBox)gvlanguage.FooterRow.FindControl("cbNewMotherTongue");

        if (e.CommandName.Equals("AddNewLanguage"))
        {
            if (lblEmployeeNumberViewEmployeejobDetail.Text != "")
            {

                if (cbNewMotherTongue.Checked)
                {
                    if (ddlNewProficiency.SelectedValue.ToString().ToLower().Trim() == "Expert".ToLower().Trim())
                    {

                        ds = objHrManagement.EmployeeLanguageInsert(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, ddlNewLanguageDesc.SelectedValue.ToString(), BaseUserID, ddlNewProficiency.SelectedValue.ToString(), cbNewMotherTongue.Checked);
                        if (gvlanguage.Rows.Count.Equals(gvlanguage.PageSize))
                        {
                            gvlanguage.PageIndex = gvTraining.PageCount + 1;
                        }
                        FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
                        DisplayMessage(lblErrorMsgLanguage, ds.Tables[0].Rows[0]["MessageID"].ToString());

                    }

                    else
                    {
                        lblErrorMsgLanguage.Text = Resources.Resource.ProficiencyShouldBeExpertIMotherTongueIsChecked;
                    }

                }
                else
                {
                    ds = objHrManagement.EmployeeLanguageInsert(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, ddlNewLanguageDesc.SelectedValue.ToString(), BaseUserID, ddlNewProficiency.SelectedValue.ToString(), cbNewMotherTongue.Checked);
                    if (gvlanguage.Rows.Count.Equals(gvlanguage.PageSize))
                    {
                        gvlanguage.PageIndex = gvTraining.PageCount + 1;
                    }
                    FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
                    DisplayMessage(lblErrorMsgLanguage, ds.Tables[0].Rows[0]["MessageID"].ToString());


                }

            }
            else
            {
                Response.Redirect("../HRManagement/EmployeeDetail.aspx");
            }
        }

    }
    /// <summary>
    /// Handles the RowDeleting event of the gvlanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvlanguage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        Label lblLanguageCode = (Label)gvlanguage.Rows[e.RowIndex].FindControl("lblLanguageCode");
        ds = objHrManagement.EmployeeLanguageDelete(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, lblLanguageCode.Text);
        FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
        DisplayMessage(lblErrorMsgLanguage, ds.Tables[0].Rows[0]["MessageID"].ToString());
    }

    /// <summary>
    /// Handles the RowEditing event of the gvlanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs"/> instance containing the event data.</param>
    protected void gvlanguage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvlanguage.EditIndex = e.NewEditIndex;
        FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
    }

    /// <summary>
    /// Handles the RowUpdating event of the gvlanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs"/> instance containing the event data.</param>
    protected void gvlanguage_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        Label lblLanguageCodeEdit = (Label)gvlanguage.Rows[e.RowIndex].FindControl("lblLanguageCodeEdit");
        DropDownList ddlProficiency = (DropDownList)gvlanguage.Rows[e.RowIndex].FindControl("ddlProficiency");
        CheckBox cbMotherTongue = (CheckBox)gvlanguage.Rows[e.RowIndex].FindControl("cbMotherTongue");

        if (cbMotherTongue.Checked)
        {
            if (ddlProficiency.SelectedValue.ToString().Trim().ToLower() == "Expert".Trim().ToLower())
            {


                ds = objHrManagement.EmployeeLanguageUpdate(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, lblLanguageCodeEdit.Text, ddlProficiency.SelectedValue.ToString(), cbMotherTongue.Checked, BaseUserID);
                gvlanguage.EditIndex = -1;
                FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
                DisplayMessage(lblErrorMsgLanguage, ds.Tables[0].Rows[0]["MessageID"].ToString());

            }

            else
            {
                lblErrorMsgLanguage.Text = Resources.Resource.ProficiencyShouldBeExpertIMotherTongueIsChecked;
            }
        }
        else
        {

            ds = objHrManagement.EmployeeLanguageUpdate(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, lblLanguageCodeEdit.Text, ddlProficiency.SelectedValue.ToString(), cbMotherTongue.Checked, BaseUserID);
            gvlanguage.EditIndex = -1;
            FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
            DisplayMessage(lblErrorMsgLanguage, ds.Tables[0].Rows[0]["MessageID"].ToString());
        }
    }
    /// <summary>
    /// Handles the PageIndexChanging event of the gvlanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewPageEventArgs"/> instance containing the event data.</param>
    protected void gvlanguage_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvlanguage.PageIndex = e.NewPageIndex;
        FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
    }
    /// <summary>
    /// Handles the RowCancelingEdit event of the gvlanguage control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs"/> instance containing the event data.</param>
    protected void gvlanguage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvlanguage.EditIndex = -1;
        FillgvLanguage(lblEmployeeNumberViewEmployeejobDetail.Text);
    }
    #endregion

    #region Function Related To Skills Grid

    /// <summary>
    /// Handles the RowDataBound event of the gvSkills control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewRowEventArgs"/> instance containing the event data.</param>
    protected void gvSkills_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }
        if (IsWriteAccess == false && IsModifyAccess == false && IsDeleteAccess == false)
        {
            gvSkills.Columns[2].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsDeleteAccess == false)
            {
                ImageButton IBDeleteSkill = (ImageButton)e.Row.FindControl("IBDeleteSkill");
                if (IBDeleteSkill != null)
                {
                    IBDeleteSkill.Visible = false;
                }
            }
            else
            {
                ImageButton IBDeleteSkill = (ImageButton)e.Row.FindControl("IBDeleteSkill");
                if (IBDeleteSkill != null)
                {
                    IBDeleteSkill.Attributes["onclick"] = "javascript:Timerf('" + lblSkillErrMsg.ClientID.ToString() + "');javascript:return confirm('" + Resources.Resource.MsgConfirmDelete + "');";
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (IsWriteAccess == false)
            {
                gvSkills.ShowFooter = false;
            }
            else
            {
                DropDownList ddlNewSkills = (DropDownList)e.Row.FindControl("ddlNewSkills");
                ImageButton ImgbtnAddSkill = (ImageButton)e.Row.FindControl("ImgbtnAddSkill");
                if (ddlNewSkills != null)
                {
                    ddlNewSkills.DataSource = objHrManagement.SkillTypeMasterGet(BaseCompanyCode);
                    ddlNewSkills.DataTextField = "ItemDesc";
                    ddlNewSkills.DataValueField = "ItemCode";
                    ddlNewSkills.DataBind();
                    if (ddlNewSkills.SelectedValue.ToString() == "")
                    {
                        ListItem li = new ListItem();
                        li.Text = Resources.Resource.NoData;
                        li.Value = "0";
                        ddlNewSkills.Items.Add(li);
                        ImgbtnAddSkill.Enabled = false;
                    }
                }

                if (ImgbtnAddSkill != null)
                {
                    ImgbtnAddSkill.Attributes["onclick"] = "javascript:Timerf('" + lblSkillErrMsg.ClientID.ToString() + "');";
                }
            }
        }
    }

    /// <summary>
    /// Handles the RowDeleting event of the gvSkills control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs"/> instance containing the event data.</param>
    protected void gvSkills_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        Label lblskilldesc = (Label)gvSkills.Rows[e.RowIndex].FindControl("lblskilldesc");

        ds = objHrManagement.EmployeeSkillsDelete(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, lblskilldesc.Text);
        FillgvSkills(lblEmployeeNumberViewEmployeejobDetail.Text);
        DisplayMessage(lblSkillErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

    }

    /// <summary>
    /// Handles the RowCommand event of the gvSkills control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs"/> instance containing the event data.</param>
    protected void gvSkills_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet ds = new DataSet();
        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();

        DropDownList ddlNewSkills = (DropDownList)gvSkills.FooterRow.FindControl("ddlNewSkills");
        if (e.CommandName.Equals("AddNewSkill"))
        {
            if (lblEmployeeNumberViewEmployeejobDetail.Text != "")
            {

                ds = objHrManagement.EmployeeSkillsInsert(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, ddlNewSkills.SelectedValue.ToString(), ddlNewSkills.SelectedItem.Text, BaseUserID);
                if (gvSkills.Rows.Count.Equals(gvSkills.PageSize))
                {
                    gvSkills.PageIndex = gvSkills.PageCount + 1;
                }

                FillgvSkills(lblEmployeeNumberViewEmployeejobDetail.Text);
                DisplayMessage(lblSkillErrMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
            }
            else
            {
                Response.Redirect("../HRManagement/EmployeeDetail.aspx");
            }

        }
    }

    /// <summary>
    /// Fillgvs the skills.
    /// </summary>
    /// <param name="strEmployeeNumber">The STR employee number.</param>
    private void FillgvSkills(string strEmployeeNumber)
    {

        BL.HRManagement objHrManagement = new BL.HRManagement();
        BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        DataSet dsSkills = new DataSet();
        int dtflag;
        dtflag = 1;
        dsSkills = objHrManagement.EmployeeSkillsGet(BaseCompanyCode, strEmployeeNumber);
        if (dsSkills.Tables[0].Rows.Count == 0)
        {
            dtflag = 0;
            dsSkills.Tables[0].Rows.Add(dsSkills.Tables[0].NewRow());
        }

        gvSkills.DataSource = dsSkills.Tables[0];
        gvSkills.DataBind();

        if (dtflag == 0)
        {
            gvSkills.Rows[0].Visible = false;
        }

    }

    #endregion

    #region Back Button Click Event
    /// <summary>
    /// Handles the Click event of the btnBack control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../HRManagement/EmployeeDetail.aspx");
    }

    /// <summary>
    /// Handles the Click event of the btnUpload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string FileName;
        String path = Server.MapPath("~/DocumentUpload/EmployeeImages/");
        FileName = path;
        FileName = FileName + lblEmployeeNumberViewEmployeejobDetail.Text + ".jpg";

        if (FileUploadEmployee.HasFile)
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
                FileUploadEmployee.PostedFile.SaveAs(FileName);

            }
            else
            {
                FileUploadEmployee.PostedFile.SaveAs(FileName);

            }
        }

        string FileNameTemp = path + "CurrentFile.jpg";
        if (FileUploadEmployee.HasFile)
        {
            if (File.Exists(FileNameTemp))
            {
                File.Delete(FileNameTemp);
                FileUploadEmployee.PostedFile.SaveAs(FileNameTemp);

            }
            else
            {
                FileUploadEmployee.PostedFile.SaveAs(FileNameTemp);

            }
        }



        string DefaultFileName = "EmpNoImage" + ".jpg";

        string ServerLocalDefaultFileName = path.ToString() + "EmpNoImage" + ".jpg";
        if (File.Exists(FileName))
        {
            if (this.ImageBox.ImageUrl.Contains("CurrentFile"))
            {
                this.ImageBox.ImageUrl = "~/DocumentUpload/EmployeeImages/" + lblEmployeeNumberViewEmployeejobDetail.Text + ".jpg";
            }
            else
            {
                this.ImageBox.ImageUrl = "~/DocumentUpload/EmployeeImages/" + "CurrentFile.jpg";
            }
        }
        else if (File.Exists(ServerLocalDefaultFileName))
        {
            this.ImageBox.ImageUrl = "~/DocumentUpload/EmployeeImages/" + DefaultFileName;
        }
    }

    #endregion
    protected void EmpDetails_ActiveTabChanged(object sender, EventArgs e)
    {
    }
    protected void FillddlCompany()
    {
        var objblUserManagement = new BL.UserManagement();
        DataSet dsCompany = objblUserManagement.UserCompanyAccessGet(SessionUserID);
        if (dsCompany.Tables[0].Rows.Count > 0)
        {
            HfCompanyCode.Value = dsCompany.Tables[0].Rows[0]["CompanyCode"].ToString();
        }
    }
    protected void FillddlHrLocation()
    {
        var objblUserManagement = new BL.UserManagement();
        DataSet dsHrLocation = objblUserManagement.UserHRLocationAccessGet(SessionUserID, HfCompanyCode.Value);
        if (dsHrLocation.Tables[0].Rows.Count > 0)
        {
            HfHrLocation.Value = dsHrLocation.Tables[0].Rows[0]["HrLocationCode"].ToString();


        }
    }


    /// <summary>
    /// Handles the OnRowEditing event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    /// 
    #region Function related to Employee Item Issuing
    protected void gvEmployeeItemIssuing_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtEditIssueingDate = (TextBox)e.Row.FindControl("txtEditIssueingDate");
            if (txtEditIssueingDate != null)
            {
                txtEditIssueingDate.Attributes.Add("readonly", "readonly");
            }
            var txtEditValidityDate = (TextBox)e.Row.FindControl("txtEditValidityDate");
            if (txtEditValidityDate != null)
            {
                txtEditValidityDate.Attributes.Add("readonly", "readonly");
            }
            var txtEditIssuedby = (TextBox)e.Row.FindControl("txtEditIssuedby");

            if (txtEditIssuedby != null)
            {
                txtEditIssuedby.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEditIssuedby.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }

            HiddenField GroupID = (HiddenField)e.Row.FindControl("GroupID");
            HiddenField hfitems = (HiddenField)e.Row.FindControl("hfitems");
            HiddenField SubgroupId = (HiddenField)e.Row.FindControl("SubgroupId");
            DropDownList ddlNewGroupID = (DropDownList)e.Row.FindControl("ddlNewGroupID");
            DropDownList ddlNewSubgroupId = (DropDownList)e.Row.FindControl("ddlNewSubgroupId");
            DropDownList ddlNewItem = (DropDownList)e.Row.FindControl("ddlNewItem");
            if (GroupID != null && ddlNewGroupID != null && ddlNewSubgroupId != null && ddlNewItem != null && SubgroupId != null && hfitems != null)
            {
                FillddlNewGroupId(ddlNewGroupID, ddlNewSubgroupId, ddlNewItem, GroupID.Value);
                ddlNewSubgroupId.SelectedValue = SubgroupId.Value;
                FillddlNewItem(ddlNewSubgroupId, ddlNewItem);
                ddlNewItem.SelectedValue = hfitems.Value;

            }



        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtNewIssueingDate = (TextBox)e.Row.FindControl("txtNewIssueingDate");
            if (txtNewIssueingDate != null)
            {
                txtNewIssueingDate.Attributes.Add("readonly", "readonly");
            }
            var txtNewValidityDate = (TextBox)e.Row.FindControl("txtNewValidityDate");
            if (txtNewValidityDate != null)
            {
                txtNewValidityDate.Attributes.Add("readonly", "readonly");
            }
            var txtNewIssuedby = (TextBox)e.Row.FindControl("txtNewIssuedby");
            if (txtNewIssuedby != null)
            {
                txtNewIssuedby.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewIssuedby.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            DropDownList ddlNewGroupID = (DropDownList)e.Row.FindControl("ddlNewGroupID");
            DropDownList ddlNewSubgroupId = (DropDownList)e.Row.FindControl("ddlNewSubgroupId");
            DropDownList ddlNewItem = (DropDownList)e.Row.FindControl("ddlNewItem");
            FillddlNewGroupId(ddlNewGroupID, ddlNewSubgroupId, ddlNewItem, string.Empty);
            // FillddlNewItem(ddlNewSubgroupId, ddlNewItem);

        }


    }

    private void FillddlNewGroupId(DropDownList ddlNewGroupID, DropDownList ddlNewSubgroupId, DropDownList ddlNewItem, string GroupID)
    {
        var objHrMGt = new BL.HRManagement();
        var ds = new DataSet();
        ds = objHrMGt.GetItemGroup();
        ddlNewGroupID.Items.Clear();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlNewGroupID.DataSource = ds.Tables[0];
            ddlNewGroupID.DataTextField = "ItemGroupName";
            ddlNewGroupID.DataValueField = "ItemGroupName";
            ddlNewGroupID.DataBind();
            if (GroupID != string.Empty)
                ddlNewGroupID.SelectedValue = GroupID;
        }
        else
        {
            ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
            ddlNewGroupID.Items.Add(li);
        }

        FillddlNewSubgroupId(ddlNewGroupID, ddlNewSubgroupId, ddlNewItem);
    }

    private void FillddlNewSubgroupId(DropDownList ddlNewGroupID, DropDownList ddlNewSubgroupId, DropDownList ddlNewItem)
    {
        if (ddlNewGroupID != null)
        {
            if (ddlNewGroupID.SelectedValue != string.Empty)
            {
                var objHrMGt = new BL.HRManagement();
                var ds1 = new DataSet();
                ds1 = objHrMGt.GetItemSubGroup(ddlNewGroupID.SelectedValue);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    ddlNewSubgroupId.DataSource = ds1.Tables[0];
                    ddlNewSubgroupId.DataTextField = "ItemSubGroupName";
                    ddlNewSubgroupId.DataValueField = "ItemSubGroupName";
                    ddlNewSubgroupId.DataBind();
                }
                else
                {
                    ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                    ddlNewSubgroupId.Items.Add(li);
                }
            }
            else
            {
                ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                ddlNewSubgroupId.Items.Add(li);
            }
        }
        FillddlNewItem(ddlNewSubgroupId, ddlNewItem);

    }
    private void FillddlNewItem(DropDownList ddlNewSubgroupId, DropDownList ddlNewItem)
    {

        if (ddlNewSubgroupId != null)
        {
            if (ddlNewSubgroupId.SelectedValue != string.Empty)
            {
                var objHrMGt = new BL.HRManagement();
                var ds1 = new DataSet();
                ds1 = objHrMGt.GetItems(ddlNewSubgroupId.SelectedValue);
                if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                {
                    ddlNewItem.DataSource = ds1.Tables[0];
                    ddlNewItem.DataTextField = "ItemName";
                    ddlNewItem.DataValueField = "ItemName";
                    ddlNewItem.DataBind();

                }
                else
                {
                    ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                    ddlNewItem.Items.Add(li);
                }
            }
            else
            {
                ListItem li = new ListItem(Resources.Resource.NoDataToShow, string.Empty);
                ddlNewItem.Items.Add(li);
            }
        }

    }
    protected void ddlEditGroupID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlNewGroupID = sender as DropDownList;
        foreach (GridViewRow row in gvEmployeeItemIssuing.Rows)
        {
            DropDownList ddlNewGroupID1 = row.FindControl("ddlNewGroupID") as DropDownList;
            DropDownList ddlNewSubgroupId = row.FindControl("ddlNewSubgroupId") as DropDownList;
            DropDownList ddlNewItem = row.FindControl("ddlNewItem") as DropDownList;
            FillddlNewSubgroupId(ddlNewGroupID1, ddlNewSubgroupId, ddlNewItem);
        }
    }
    protected void ddlEditSubGroupID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlNewSubgroupId = sender as DropDownList;
        foreach (GridViewRow row in gvEmployeeItemIssuing.Rows)
        {
            DropDownList ddlNewGroupID = row.FindControl("ddlNewGroupID") as DropDownList;
            DropDownList ddlNewSubgroupId1 = row.FindControl("ddlNewSubgroupId") as DropDownList;
            DropDownList ddlNewItem = row.FindControl("ddlNewItem") as DropDownList;
            FillddlNewItem(ddlNewSubgroupId1, ddlNewItem);
        }


    }
    protected void ddlNewGroupID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlNewGroupID = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewGroupID");
        DropDownList ddlNewSubgroupId = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewSubgroupId");
        DropDownList ddlNewItem = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewItem");
        FillddlNewSubgroupId(ddlNewGroupID, ddlNewSubgroupId, ddlNewItem);

    }
    protected void ddlNewSubGroupID_SelectedIndexChanged(object sender, EventArgs e)
    {
        // DropDownList ddlNewGroupID = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewGroupID");
        DropDownList ddlNewSubgroupId = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewSubgroupId");
        DropDownList ddlNewItem = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewItem");
        FillddlNewItem(ddlNewSubgroupId, ddlNewItem);

    }

    protected void FillgvEmployeeItemIssuing()
    {
        try
        {
            int dtflag;
            var objblUserManagement = new BL.HRManagement();
            DataTable dtItemIssuing = new DataTable();
            string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
            DataSet dsItemIssuing = objblUserManagement.GetEmployeeItemIssuing(empid);
            dtflag = 1;
            dtItemIssuing = dsItemIssuing.Tables[0];

            if (dtItemIssuing.Rows.Count == 0)
            {
                dtflag = 0;
                dtItemIssuing.Rows.Add(dtItemIssuing.NewRow());
            }
            gvEmployeeItemIssuing.DataSource = dtItemIssuing;
            gvEmployeeItemIssuing.DataBind();
            if (dtflag == 0)
            {
                gvEmployeeItemIssuing.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void gvEmployeeItemIssuing_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployeeItemIssuing.EditIndex = e.NewEditIndex;
        FillgvEmployeeItemIssuing();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeItemIssuing_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        //      
        var ID = (HiddenField)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("ItemDetailID");
        var txtEditIssuengBranch = (TextBox)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("txtEditIssuengBranch");
        var ddlNewGroupID = (DropDownList)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("ddlNewGroupID");
        var ddlNewSubgroupId = (DropDownList)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("ddlNewSubgroupId");
        var txtEditValidityDate = (TextBox)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("txtEditValidityDate");
        var txtEditIssueingDate = (TextBox)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("txtEditIssueingDate");
        var ddlNewItem = (DropDownList)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("ddlNewItem");
        var txtEditIssuedby = (TextBox)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("txtEditIssuedby");
        var txtQuantity = (TextBox)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("txtQuantity");
        var strTimeFrom = string.Empty;
        if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
        {
            Show("Please enter only numbers in Quantity.");
            txtQuantity.Focus();
            txtQuantity.Text = "";
            return;
        }
        if (txtEditIssueingDate.Text != "" && txtEditValidityDate.Text != "")
        {
            if (DateTime.Parse(txtEditIssueingDate.Text) >= DateTime.Parse(txtEditValidityDate.Text))
            {
                lblItem.Text = Resources.Resource.DateofIssueCannotEqualOrGreaterThanDateOfExpiry; //@"Date Of Issue cannot be equal to or greater than Date of Expiry";
                toolkitScriptManager1.SetFocus(txtEditValidityDate);
                return;
            }
        }
        ds = objHrManagement.EmployeeIssuingInsert(lblEmployeeNumberViewEmployeejobDetail.Text, BaseCompanyCode, Convert.ToInt32(ID.Value), ddlNewItem.SelectedValue, ddlNewGroupID.SelectedValue, ddlNewSubgroupId.SelectedValue, Convert.ToInt32(txtQuantity.Text), txtEditIssueingDate.Text.Trim(), txtEditValidityDate.Text.Trim(), "", txtEditIssuedby.Text.Trim(), BaseUserID);
        if (Convert.ToInt32(ds.Tables[0].Rows[0]["MessageId"].ToString()) >= 0)
        {
            DisplayMessage(lblItem, ds.Tables[0].Rows[0]["MessageId"].ToString());
        }
        else
        {
            DisplayMessageForResourceKey(lblItem, ds.Tables[0].Rows[0]["MessageStrID"].ToString());
        }
        gvEmployeeItemIssuing.EditIndex = -1;
        FillgvEmployeeItemIssuing();

    }
    /// <summary>
    /// Handles the OnRowCancelingEdit event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeItemIssuing_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvEmployeeItemIssuing.EditIndex = -1;
        FillgvEmployeeItemIssuing();

    }
    /// <summary>
    /// Handles the RowCommand event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeItemIssuing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            var ds = new DataSet();
            var objHrManagement = new BL.HRManagement();
            HiddenField hidItemDetail = (HiddenField)gvEmployeeItemIssuing.FooterRow.FindControl("hidItemDetail");
            DropDownList ddlNewItem = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewItem");

            DropDownList ddlNewGroupID = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewGroupID");
            DropDownList ddlNewSubgroupId = (DropDownList)gvEmployeeItemIssuing.FooterRow.FindControl("ddlNewSubgroupId");
            TextBox txtNewValidityDate = (TextBox)gvEmployeeItemIssuing.FooterRow.FindControl("txtNewValidityDate");
            TextBox txtNewIssueingDate = (TextBox)gvEmployeeItemIssuing.FooterRow.FindControl("txtNewIssueingDate");
            TextBox txtNewIssuedby = (TextBox)gvEmployeeItemIssuing.FooterRow.FindControl("txtNewIssuedby");
            var txtQuantity = (TextBox)gvEmployeeItemIssuing.FooterRow.FindControl("txtQuantity");

            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]"))
            {
                Show("Please enter only numbers in Quantity.");
                txtQuantity.Focus();
                txtQuantity.Text = "";
                return;
            }
            if(txtQuantity.Text =="0")
            {
                Show("Quantity cannot be entered as Zero.");
                txtQuantity.Focus();
                txtQuantity.Text = "";
                return;
            }
           var strTimeFrom = string.Empty;
            if (e.CommandName == "AddNew")
            {
                if (txtNewIssueingDate.Text != "" && txtNewValidityDate.Text != "")
                {
                    if (DateTime.Parse(txtNewIssueingDate.Text) >= DateTime.Parse(txtNewValidityDate.Text))
                    {
                        lblItem.Text = Resources.Resource.DateofIssueCannotEqualOrGreaterThanDateOfExpiry; //@"Date Of Issue cannot be equal to or greater than Date of Expiry";
                        toolkitScriptManager1.SetFocus(txtNewValidityDate);
                        return;
                    }
                }
               
                    ds = objHrManagement.EmployeeIssuingInsert(lblEmployeeNumberViewEmployeejobDetail.Text, BaseCompanyCode, Convert.ToInt32(hidItemDetail.Value), ddlNewItem.SelectedValue, ddlNewGroupID.SelectedValue, ddlNewSubgroupId.SelectedValue, Convert.ToInt32(txtQuantity.Text), txtNewIssueingDate.Text.Trim(), txtNewValidityDate.Text.Trim(), "", txtNewIssuedby.Text.Trim(), BaseUserID);
               
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["MessageId"].ToString()) >= 0)
                {
                    DisplayMessage(lblItem, ds.Tables[0].Rows[0]["MessageId"].ToString());
                }
                else
                {
                    DisplayMessageForResourceKey(lblItem, ds.Tables[0].Rows[0]["MessageStrID"].ToString());
                }

                FillgvEmployeeItemIssuing();

            }
            if (e.CommandName == "Reset")
            {
                txtNewIssuedby.Text = "";
                txtNewIssueingDate.Text = "";
                txtNewValidityDate.Text = "";
                txtQuantity.Text = "";
            }
        }
        catch (Exception ex)
        {

        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeItemIssuing_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField ID = (HiddenField)gvEmployeeItemIssuing.Rows[e.RowIndex].FindControl("ID");
        ds = objHrManagement.EmployeeItemIssuingDelete(Convert.ToInt32(ID.Value));
        DisplayMessage(lblItem, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvEmployeeItemIssuing.EditIndex = -1;
        FillgvEmployeeItemIssuing();


    }
    protected void gvEmployeeItemIssuing_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeItemIssuing.PageIndex = e.NewPageIndex;
        gvEmployeeItemIssuing.EditIndex = -1;
        FillgvEmployeeItemIssuing();

    }
    #endregion
    #region Function related to Employee Reference Details
    protected void FillgvEmployeeReferenceDetail()
    {
        try
        {
            int dtflag;
            var objblUserManagement = new BL.HRManagement();
            DataTable dtItemIssuing = new DataTable();
            string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
            DataSet dsItemIssuing = objblUserManagement.GetEmployeeReferenceDetail(empid);
            dtflag = 1;
            dtItemIssuing = dsItemIssuing.Tables[0];
            if (dtItemIssuing.Rows.Count == 0)
            {
                dtflag = 0;
                dtItemIssuing.Rows.Add(dtItemIssuing.NewRow());
            }
            gvEmployeeReferenceDetails.DataSource = dtItemIssuing;
            gvEmployeeReferenceDetails.DataBind();
            if (dtflag == 0)
            {
                gvEmployeeReferenceDetails.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void gvEmployeeReferenceDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtEditName = (TextBox)e.Row.FindControl("txtEditName");
            var txtEditDesignation = (TextBox)e.Row.FindControl("txtEditDesignation");
            var txtEditArea = (TextBox)e.Row.FindControl("txtEditArea");
            var txtEditRelationshipRefernce = (TextBox)e.Row.FindControl("txtEditRelationshipRefernce");
            var txtOrganization = (TextBox)e.Row.FindControl("txtOrganization");
            var txtEditMobile = (TextBox)e.Row.FindControl("txtEditMobile");
            
            if (txtEditName != null)
            {
                txtEditName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEditName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtEditDesignation != null)
            {
                txtEditDesignation.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEditDesignation.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtEditArea != null)
            {
                txtEditArea.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEditArea.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtEditRelationshipRefernce != null)
            {
                txtEditRelationshipRefernce.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEditRelationshipRefernce.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtOrganization != null)
            {
                txtOrganization.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtOrganization.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtEditMobile != null)
            {
                txtEditMobile.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtEditMobile.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtNewName = (TextBox)e.Row.FindControl("txtNewName");
            var txtNewDesignation = (TextBox)e.Row.FindControl("txtNewDesignation");
            var txtNewArea = (TextBox)e.Row.FindControl("txtNewArea");
            var txtNewRelationshipRefernce = (TextBox)e.Row.FindControl("txtNewRelationshipRefernce");
            var txtOrganization = (TextBox)e.Row.FindControl("txtOrganization");
            var txtNewMobile = (TextBox)e.Row.FindControl("txtNewMobile");
            if (txtNewName != null)
            {
                txtNewName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtNewDesignation != null)
            {
                txtNewDesignation.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewDesignation.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtNewArea != null)
            {
                txtNewArea.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewArea.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtNewRelationshipRefernce != null)
            {
                txtNewRelationshipRefernce.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewRelationshipRefernce.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtOrganization != null)
            {
                txtOrganization.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtOrganization.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtNewMobile != null)
            {
                txtNewMobile.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewMobile.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
        }

    }
    /// <summary>
    /// Handles the OnRowEditing event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeReferenceDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployeeReferenceDetails.EditIndex = e.NewEditIndex;
        FillgvEmployeeReferenceDetail();
    }
    /// <summary>
    /// Handles the RowUpdating event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeReferenceDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField hidrefenceID = (HiddenField)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("hfRefernceID");
        // HiddenField RefernceID = (HiddenField)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("RefernceID");
        TextBox txtNewName = (TextBox)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("txtEditName");
        TextBox txtNewDesignation = (TextBox)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("txtEditDesignation");
        TextBox txtNewArea = (TextBox)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("txtEditArea");
        TextBox txtOrganization = (TextBox)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("txtOrganization");
        TextBox txtNewMobile = (TextBox)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("txtEditMobile");
        TextBox txtNewRelationshipRefernce = (TextBox)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("txtEditRelationshipRefernce");
        ds = objHrManagement.EmployeeReferenceDetails(lblEmployeeNumberViewEmployeejobDetail.Text, BaseCompanyCode, Convert.ToInt32(hidrefenceID.Value), txtNewName.Text.Trim(), txtNewDesignation.Text, txtNewArea.Text.Trim(), txtNewRelationshipRefernce.Text.Trim(), txtOrganization.Text, txtNewMobile.Text.Trim(), lblEmployeeNumberViewEmployeejobDetail.Text);
        gvEmployeeReferenceDetails.EditIndex = -1;
        DisplayMessage(lblreference, ds.Tables[0].Rows[0]["MessageId"].ToString());
        FillgvEmployeeReferenceDetail();
    }
    /// <summary>
    /// Handles the OnRowCancelingEdit event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCancelEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeReferenceDetails_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvEmployeeReferenceDetails.EditIndex = -1;
        FillgvEmployeeReferenceDetail();

    }
    /// <summary>
    /// Handles the RowCommand event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeReferenceDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            //   HiddenField hidrefenceID = (HiddenField)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("hfRefernceID");
            TextBox txtNewName = (TextBox)gvEmployeeReferenceDetails.FooterRow.FindControl("txtNewName");
            TextBox txtNewDesignation = (TextBox)gvEmployeeReferenceDetails.FooterRow.FindControl("txtNewDesignation");
            TextBox txtNewArea = (TextBox)gvEmployeeReferenceDetails.FooterRow.FindControl("txtNewArea");
            TextBox txtOrganization = (TextBox)gvEmployeeReferenceDetails.FooterRow.FindControl("txtOrganization");
            TextBox txtNewMobile = (TextBox)gvEmployeeReferenceDetails.FooterRow.FindControl("txtNewMobile");
            TextBox txtNewRelationshipRefernce = (TextBox)gvEmployeeReferenceDetails.FooterRow.FindControl("txtNewRelationshipRefernce");

            if (e.CommandName == "AddNew")
            {
                var ds = new DataSet();
                var objHrManagement = new BL.HRManagement();
                HiddenField hidrefenceID = (HiddenField)gvEmployeeReferenceDetails.FooterRow.FindControl("hidrefenceID");
                var strTimeFrom = string.Empty;
                ds = objHrManagement.EmployeeReferenceDetails(lblEmployeeNumberViewEmployeejobDetail.Text, BaseCompanyCode, Convert.ToInt32(hidrefenceID.Value), txtNewName.Text.Trim(), txtNewDesignation.Text, txtNewArea.Text.Trim(), txtNewRelationshipRefernce.Text.Trim(), txtOrganization.Text, txtNewMobile.Text.Trim(), lblEmployeeNumberViewEmployeejobDetail.Text);

                DisplayMessage(lblreference, ds.Tables[0].Rows[0]["MessageId"].ToString());
                FillgvEmployeeReferenceDetail();

            }
            if (e.CommandName == "Reset")
            {
                txtNewArea.Text = "";
                txtNewDesignation.Text = "";
                txtNewName.Text = "";
                txtNewMobile.Text = "";
                txtOrganization.Text = string.Empty;
                txtNewRelationshipRefernce.Text = "";
            }
        }
        catch (Exception ex)
        {

        }
    }
    /// <summary>
    /// Handles the RowDeleting event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewDeleteEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeReferenceDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        //  HiddenField ID = (HiddenField)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("hfReferenceID");

        HiddenField ID = (HiddenField)gvEmployeeReferenceDetails.Rows[e.RowIndex].FindControl("hfRefernceID");
        ds = objHrManagement.EmployeeReferenceDetailsDelete(Convert.ToInt32(ID.Value));
        gvEmployeeReferenceDetails.EditIndex = -1;
        DisplayMessage(lblreference, ds.Tables[0].Rows[0]["MessageId"].ToString());
        FillgvEmployeeReferenceDetail();


    }
    protected void gvEmployeeReferenceDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeReferenceDetails.PageIndex = e.NewPageIndex;
        gvEmployeeReferenceDetails.EditIndex = -1;
        FillgvEmployeeReferenceDetail();

    }
    #endregion
    #region Functions related to Employee Education
    protected void FillgvEmployeeEducationDetail()
    {
        try
        {
            int dtflag;
            var objblUserManagement = new BL.HRManagement();
            DataTable dtItemIssuing = new DataTable();
            string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
            DataSet dsItemIssuing = objblUserManagement.GetEmployeeEducationDetail(empid);
            dtflag = 1;
            dtItemIssuing = dsItemIssuing.Tables[0];
            if (dtItemIssuing.Rows.Count == 0)
            {
                dtflag = 0;
                dtItemIssuing.Rows.Add(dtItemIssuing.NewRow());
            }
            gvEmployeeEducational.DataSource = dtItemIssuing;
            gvEmployeeEducational.DataBind();
            if (dtflag == 0)
            {
                gvEmployeeEducational.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void gvEmployeeEducational_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtEditClass = (TextBox)e.Row.FindControl("txtEditClass");
            var txtEditSpecialization = (TextBox)e.Row.FindControl("txtEditSpecialization");
            var txtEditGrade = (TextBox)e.Row.FindControl("txtEditGrade");
            var txtUniversity = (TextBox)e.Row.FindControl("txtUniversity");
            var txtEditYearofcompletion = (TextBox)e.Row.FindControl("txtEditYearofcompletion");
            if (txtEditYearofcompletion != null)
            {
                txtEditYearofcompletion.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtEditYearofcompletion.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }
            if (txtEditClass != null)
            {
                txtEditClass.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEditClass.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtEditSpecialization != null)
            {
                txtEditSpecialization.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEditSpecialization.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtEditGrade != null)
            {
                txtEditGrade.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtEditGrade.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtUniversity != null)
            {
                txtUniversity.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtUniversity.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            HiddenField hfqualificationcode = (HiddenField)e.Row.FindControl("hfqualificationcode");
            var ddlQualificationDesc = (DropDownList)e.Row.FindControl("ddlQualificationDesc");
            if (ddlQualificationDesc != null && hfqualificationcode != null)
            {
                FillddlQualificationDesc(ddlQualificationDesc, hfqualificationcode.Value);
            }
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtNewClass = (TextBox)e.Row.FindControl("txtNewClass");
            var txtNewSpecialization = (TextBox)e.Row.FindControl("txtNewSpecialization");
            var txtNewGrade = (TextBox)e.Row.FindControl("txtNewGrade");
            var txtUniversity = (TextBox)e.Row.FindControl("txtUniversity");
            var txtNewYearofcompletion = (TextBox)e.Row.FindControl("txtNewYearofcompletion");
            if (txtNewYearofcompletion != null)
            {
                txtNewYearofcompletion.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
                txtNewYearofcompletion.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionNum + ");");
            }
            if (txtNewClass != null)
            {
                txtNewClass.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewClass.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtNewSpecialization != null)
            {
                txtNewSpecialization.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewSpecialization.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtNewGrade != null)
            {
                txtNewGrade.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtNewGrade.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtUniversity != null)
            {
                txtUniversity.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtUniversity.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            var ddlQualificationDesc = (DropDownList)e.Row.FindControl("ddlQualificationDesc");
            if (ddlQualificationDesc != null)
            {
                FillddlQualificationDesc(ddlQualificationDesc, string.Empty);
            }
        }
    }

    public void FillddlQualificationDesc(DropDownList ddlQualificationDesc, string hfqualificationcode)
    {
        var objMastersManagement = new BL.MastersManagement();
        var ds = new DataSet();
        ds = objMastersManagement.QualificationMasterGetAll();
        ddlQualificationDesc.Items.Clear();
        //  BL.MastersManagement objMastersManagement = new BL.MastersManagement();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            ddlQualificationDesc.DataSource = ds.Tables[0];
            ddlQualificationDesc.DataTextField = "QualificationDesc";
            ddlQualificationDesc.DataValueField = "QualificationCode";
            ddlQualificationDesc.DataBind();
            if (hfqualificationcode != string.Empty)
                ddlQualificationDesc.SelectedValue = hfqualificationcode;
        }
    }

    /// <summary>
    /// Handles the OnRowEditing event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewEditEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeEducational_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployeeEducational.EditIndex = e.NewEditIndex;
        FillgvEmployeeEducationDetail();

    }
    /// <summary>
    /// Handles the RowUpdating event of the gvEmployeePreferances control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="GridViewUpdateEventArgs" /> instance containing the event data.</param>
    protected void gvEmployeeEducational_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField EducationID = (HiddenField)gvEmployeeEducational.Rows[e.RowIndex].FindControl("EducationID");
        TextBox txtNewClass = (TextBox)gvEmployeeEducational.Rows[e.RowIndex].FindControl("txtEditClass");
        TextBox txtNewGrade = (TextBox)gvEmployeeEducational.Rows[e.RowIndex].FindControl("txtEditGrade");
        TextBox txtNewSpecialization = (TextBox)gvEmployeeEducational.Rows[e.RowIndex].FindControl("txtEditSpecialization");
        TextBox txtNewYearofcompletion = (TextBox)gvEmployeeEducational.Rows[e.RowIndex].FindControl("txtEditYearofcompletion");
        TextBox txtUniversity = (TextBox)gvEmployeeEducational.Rows[e.RowIndex].FindControl("txtUniversity");
        DropDownList ddlQualificationDesc = (DropDownList)gvEmployeeEducational.Rows[e.RowIndex].FindControl("ddlQualificationDesc");
        var strTimeFrom = string.Empty;
       
            ds = objHrManagement.EmployeeEducationInsert(Convert.ToInt32(EducationID.Value), lblEmployeeNumberViewEmployeejobDetail.Text, BaseCompanyCode, txtNewClass.Text.Trim(), txtNewSpecialization.Text, txtNewGrade.Text.Trim(), txtNewYearofcompletion.Text.Trim(), BaseUserID, ddlQualificationDesc.SelectedValue, txtUniversity.Text);
            if (Convert.ToInt32(ds.Tables[0].Rows[0]["MessageId"].ToString()) >= 0)
            {
                DisplayMessage(lblEducation, ds.Tables[0].Rows[0]["MessageId"].ToString());
            }
            else
            {
                DisplayMessageForResourceKey(lblEducation, ds.Tables[0].Rows[0]["MessageStrID"].ToString());
            }
            gvEmployeeEducational.EditIndex = -1;
            FillgvEmployeeEducationDetail();
       

    }

    protected void gvEmployeeEducational_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvEmployeeEducational.EditIndex = -1;
        FillgvEmployeeEducationDetail();


    }

    protected void gvEmployeeEducational_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            TextBox txtNewClass = (TextBox)gvEmployeeEducational.FooterRow.FindControl("txtNewClass");
            TextBox txtNewGrade = (TextBox)gvEmployeeEducational.FooterRow.FindControl("txtNewGrade");
            TextBox txtNewSpecialization = (TextBox)gvEmployeeEducational.FooterRow.FindControl("txtNewSpecialization");
            TextBox txtNewYearofcompletion = (TextBox)gvEmployeeEducational.FooterRow.FindControl("txtNewYearofcompletion");
            TextBox txtUniversity = (TextBox)gvEmployeeEducational.FooterRow.FindControl("txtUniversity");
            if (e.CommandName == "AddNew")
            {
                var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                var ds = new DataSet();
                var objHrManagement = new BL.HRManagement();
                // BL.MastersManagement objMastersManagement = new BL.MastersManagement();
                HiddenField EducationID = (HiddenField)gvEmployeeEducational.FooterRow.FindControl("NewEducationID");

                DropDownList ddlQualificationDesc = (DropDownList)gvEmployeeEducational.FooterRow.FindControl("ddlQualificationDesc");
                //HiddenField hfqualificationcode = (HiddenField)gvEmployeeEducational.FooterRow.FindControl("hfqualificationcode");
                var strTimeFrom = string.Empty;

                    ds = objHrManagement.EmployeeEducationInsert(Convert.ToInt32(EducationID.Value), lblEmployeeNumberViewEmployeejobDetail.Text, BaseCompanyCode, txtNewClass.Text.Trim(), txtNewSpecialization.Text, txtNewGrade.Text.Trim(), txtNewYearofcompletion.Text.Trim(), BaseUserID, ddlQualificationDesc.SelectedValue, txtUniversity.Text);
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["MessageId"].ToString()) >= 0)
                    {
                        DisplayMessage(lblEducation, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    }
                    else
                    {
                        DisplayMessageForResourceKey(lblEducation, ds.Tables[0].Rows[0]["MessageStrID"].ToString());
                    }
                    FillgvEmployeeEducationDetail();
                
            }
            if (e.CommandName.Equals("Reset"))
            {
                txtUniversity.Text = "";
                txtNewClass.Text = "";
                txtNewSpecialization.Text = "";
                txtNewGrade.Text = "";
                txtNewYearofcompletion.Text = "";
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvEmployeeEducational_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField ID = (HiddenField)gvEmployeeEducational.Rows[e.RowIndex].FindControl("EducationID");
        ds = objHrManagement.EmplyoyeeEducationdetailDelete(Convert.ToInt32(ID.Value));
        DisplayMessage(lblEducation, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvEmployeeItemIssuing.EditIndex = -1;
        FillgvEmployeeEducationDetail();
    }
    protected void gvEmployeeEducational_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeItemIssuing.PageIndex = e.NewPageIndex;
        gvEmployeeItemIssuing.EditIndex = -1;

    }
    #endregion

    #region Function related to Employee Experience
    protected void FillgvEmployeeExperience()
    {
        try
        {
            int dtflag;
            var objblUserManagement = new BL.HRManagement();
            DataTable dtExperience = new DataTable();
            string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
            DataSet dsExperience = objblUserManagement.GetEmployeeExperienceDetail(empid);
            dtflag = 1;
            dtExperience = dsExperience.Tables[0];
           if (dtExperience.Rows.Count == 0)
            {
                dtflag = 0;
                dtExperience.Rows.Add(dtExperience.NewRow());
            }
            gvEmployeeExperience.DataSource = dtExperience;
            gvEmployeeExperience.DataBind();
            if (dtflag == 0)
            {
                gvEmployeeExperience.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvEmployeeExperience_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtFromDate = (TextBox)e.Row.FindControl("txtFromDate");
            if (txtFromDate != null)
            {
                txtFromDate.Attributes.Add("readonly", "readonly");
            }
            var txtToDate = (TextBox)e.Row.FindControl("txtToDate");
            if (txtToDate != null)
            {
                txtToDate.Attributes.Add("readonly", "readonly");
            }
            var txtDesignation = (TextBox)e.Row.FindControl("txtDesignation");
            var txtDepartment = (TextBox)e.Row.FindControl("txtDepartment");
            var txtCompanyName = (TextBox)e.Row.FindControl("txtCompanyName");
            var txtAddress = (TextBox)e.Row.FindControl("txtAddress");
            if (txtDesignation != null)
            {
                txtDesignation.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDesignation.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtDepartment != null)
            {
                txtDepartment.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDepartment.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtCompanyName != null)
            {
                txtCompanyName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtCompanyName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtAddress != null)
            {
                txtAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }

        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtFromDate = (TextBox)e.Row.FindControl("txtFromDate");
            if (txtFromDate != null)
            {
                txtFromDate.Attributes.Add("readonly", "readonly");
            }
            var txtToDate = (TextBox)e.Row.FindControl("txtToDate");
            if (txtToDate != null)
            {
                txtToDate.Attributes.Add("readonly", "readonly");
            }
            var txtDesignation = (TextBox)e.Row.FindControl("txtDesignation");
            var txtDepartment = (TextBox)e.Row.FindControl("txtDepartment");
            var txtCompanyName = (TextBox)e.Row.FindControl("txtCompanyName");
            var txtAddress = (TextBox)e.Row.FindControl("txtAddress");
            if (txtDesignation != null)
            {
                txtDesignation.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDesignation.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtDepartment != null)
            {
                txtDepartment.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDepartment.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtCompanyName != null)
            {
                txtCompanyName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtCompanyName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtAddress != null)
            {
                txtAddress.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtAddress.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
        }

    }
    protected void gvEmployeeExperience_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmployeeExperience.EditIndex = e.NewEditIndex;
        FillgvEmployeeExperience();
    }
    protected void gvEmployeeExperience_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            var ds = new DataSet();
            var objHrManagement = new BL.HRManagement();
            HiddenField hfExperienceId = (HiddenField)gvEmployeeExperience.Rows[e.RowIndex].FindControl("hfExperienceId");

            TextBox txtDesignation = (TextBox)gvEmployeeExperience.Rows[e.RowIndex].FindControl("txtDesignation");
            TextBox txtDepartment = (TextBox)gvEmployeeExperience.Rows[e.RowIndex].FindControl("txtDepartment");
            TextBox txtCompanyName = (TextBox)gvEmployeeExperience.Rows[e.RowIndex].FindControl("txtCompanyName");

            TextBox txtAddress = (TextBox)gvEmployeeExperience.Rows[e.RowIndex].FindControl("txtAddress");
            TextBox txtFromDate = (TextBox)gvEmployeeExperience.Rows[e.RowIndex].FindControl("txtFromDate");
            TextBox txtToDate = (TextBox)gvEmployeeExperience.Rows[e.RowIndex].FindControl("txtToDate");
            if (txtFromDate.Text != "" && txtToDate.Text != "")
            {
                if (DateTime.Parse(txtFromDate.Text) >= DateTime.Parse(txtToDate.Text))
                {
                    lblExperience.Text = Resources.Resource.ToDateCannotEqualOrLesserThanFromDate; //@"Date Of Issue cannot be equal to or greater than Date of Expiry";
                    toolkitScriptManager1.SetFocus(txtToDate);
                    return;
                }
            }
            if (DateTime.Parse(txtToDate.Text) < DateTime.Today)
            {
                ds = objHrManagement.EmployeeExperienceDetails(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, txtDesignation.Text, txtDepartment.Text, txtCompanyName.Text, txtAddress.Text, txtFromDate.Text, txtToDate.Text, BaseUserID, Convert.ToInt32(hfExperienceId.Value));
                gvEmployeeExperience.EditIndex = -1;
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["MessageId"].ToString()) >= 0)
                {
                    DisplayMessage(lblExperience, ds.Tables[0].Rows[0]["MessageId"].ToString());
                }
                else
                {
                    DisplayMessageForResourceKey(lblExperience, ds.Tables[0].Rows[0]["MessageStrID"].ToString());
                }

                FillgvEmployeeExperience();
            }
            else
            { lblExperience.Text = Resources.Resource.ToDateCannotEqualOrGreaterThanTodaysDate; }

        }
        catch (Exception ex)
        { }

    }

    protected void gvEmployeeExperience_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            HiddenField hfexperienceid = (HiddenField)gvEmployeeExperience.FooterRow.FindControl("hfexperienceid");
            TextBox txtDesignation = (TextBox)gvEmployeeExperience.FooterRow.FindControl("txtDesignation");
            TextBox txtDepartment = (TextBox)gvEmployeeExperience.FooterRow.FindControl("txtDepartment");
            TextBox txtCompanyName = (TextBox)gvEmployeeExperience.FooterRow.FindControl("txtCompanyName");
            TextBox txtAddress = (TextBox)gvEmployeeExperience.FooterRow.FindControl("txtAddress");
            TextBox txtFromDate = (TextBox)gvEmployeeExperience.FooterRow.FindControl("txtFromDate");
            TextBox txtToDate = (TextBox)gvEmployeeExperience.FooterRow.FindControl("txtToDate");

            if (e.CommandName == "AddNew")
            {
                var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                var ds = new DataSet();
                var objHrManagement = new BL.HRManagement();
                //  HiddenField hidrefenceID = (HiddenField)gvEmployeeReferenceDetails.FooterRow.FindControl("hidrefenceID");
                var strTimeFrom = string.Empty;
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    if (DateTime.Parse(txtFromDate.Text) >= DateTime.Parse(txtToDate.Text))
                    {
                        lblExperience.Text = Resources.Resource.ToDateCannotEqualOrLesserThanFromDate;//@"Date Of Issue cannot be equal to or greater than Date of Expiry";
                        toolkitScriptManager1.SetFocus(txtToDate);
                        return;
                    }
                }
                if (DateTime.Parse(txtToDate.Text) < DateTime.Today)
                {
                    if (DateTime.Compare(DateTime.Parse(txtFromDate.Text), DateTime.Parse(lblDOB.Value).AddYears(18)) >= 0)
                    { 
                    ds = objHrManagement.EmployeeExperienceDetails(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, txtDesignation.Text, txtDepartment.Text, txtCompanyName.Text, txtAddress.Text, txtFromDate.Text, txtToDate.Text, BaseUserID, Convert.ToInt32(hfexperienceid.Value));
                    
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["MessageId"].ToString()) >= 0)
                    {
                        DisplayMessage(lblExperience, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    }
                    else
                    {
                        DisplayMessageForResourceKey(lblExperience, ds.Tables[0].Rows[0]["MessageStrID"].ToString());
                    }
                    FillgvEmployeeExperience();
                    }
                    else
                    {
                        lblExperience.Text = Resources.Resource.ExperienceGreaterThanDOBby18;
                    }
                   
                }
                else
                { lblExperience.Text = Resources.Resource.ToDateCannotEqualOrGreaterThanTodaysDate; }

            }
            if (e.CommandName == "Reset")
            {

                txtDepartment.Text = "";
                txtDesignation.Text = "";
                txtCompanyName.Text = "";
                txtAddress.Text = "";
                txtToDate.Text = "";
                txtFromDate.Text = "";

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvEmployeeExperience_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvEmployeeExperience.EditIndex = -1;
        FillgvEmployeeExperience();

    }

    protected void gvEmployeeExperience_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField ID = (HiddenField)gvEmployeeExperience.Rows[e.RowIndex].FindControl("hfExperienceId");
        ds = objHrManagement.EmplyoyeeExperienceDetailDelete(Convert.ToInt32(ID.Value));
        DisplayMessage(lblExperience, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvEmployeeExperience.EditIndex = -1;
        FillgvEmployeeExperience();

    }
    protected void gvEmployeeExperience_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployeeExperience.PageIndex = e.NewPageIndex;
        gvEmployeeExperience.EditIndex = -1;
        FillgvEmployeeExperience();

    }
    #endregion
    #region Function related to Employee ReferredBy

    protected void FillgvEmpReferredBy()
    {
        try
        {
            int dtflag;
            var objblUserManagement = new BL.HRManagement();
            DataTable dtRefferedBy = new DataTable();
            string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
            DataSet dsRefferedBy = objblUserManagement.GetEmployeeRefferedBYDetail(empid);
            dtflag = 1;
            dtRefferedBy = dsRefferedBy.Tables[0];
            if (dtRefferedBy.Rows.Count == 0)
            {
                dtflag = 0;
                dtRefferedBy.Rows.Add(dtRefferedBy.NewRow());
            }
            gvEmpReferredBy.DataSource = dtRefferedBy;
            gvEmpReferredBy.DataBind();
            if (dtflag == 0)
            {
                gvEmpReferredBy.Rows[0].Visible = false;
                dtflag = 0;
            }
            else
            {
                dtflag = 1;
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvEmpReferredBy_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtRefererEmployeeNumber = (TextBox)e.Row.FindControl("txtRefererEmployeeNumber");
            var txtRefererEmployeeName = (TextBox)e.Row.FindControl("txtRefererEmployeeName");
            var txtLocationDesc = (TextBox)e.Row.FindControl("txtLocationDesc");
            var txtDesignationDesc = (TextBox)e.Row.FindControl("txtDesignationDesc");
            var txtDepartmentName = (TextBox)e.Row.FindControl("txtDepartmentName");
            if (txtRefererEmployeeNumber != null)
            {
                txtRefererEmployeeNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRefererEmployeeNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtRefererEmployeeName != null)
            {
                txtRefererEmployeeName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRefererEmployeeName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtLocationDesc != null)
            {
                txtLocationDesc.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtLocationDesc.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtDesignationDesc != null)
            {
                txtDesignationDesc.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDesignationDesc.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtDepartmentName != null)
            {
                txtDepartmentName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDepartmentName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }

        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            var txtRefererEmployeeNumber = (TextBox)e.Row.FindControl("txtRefererEmployeeNumber");
            var txtRefererEmployeeName = (TextBox)e.Row.FindControl("txtRefererEmployeeName");
            var txtLocationDesc = (TextBox)e.Row.FindControl("txtLocationDesc");
            var txtDesignationDesc = (TextBox)e.Row.FindControl("txtDesignationDesc");
            var txtDepartmentName = (TextBox)e.Row.FindControl("txtDepartmentName");
            if (txtRefererEmployeeNumber != null)
            {
                txtRefererEmployeeNumber.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRefererEmployeeNumber.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtRefererEmployeeName != null)
            {
                txtRefererEmployeeName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtRefererEmployeeName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtLocationDesc != null)
            {
                txtLocationDesc.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtLocationDesc.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");

            }
            if (txtDesignationDesc != null)
            {
                txtDesignationDesc.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDesignationDesc.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }
            if (txtDepartmentName != null)
            {
                txtDepartmentName.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
                txtDepartmentName.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            }

        }

    }
    protected void gvEmpReferredBy_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvEmpReferredBy.EditIndex = e.NewEditIndex;
        FillgvEmpReferredBy();
    }
    protected void gvEmpReferredBy_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        try
        {
            var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
            var ds = new DataSet();
            var objHrManagement = new BL.HRManagement();
            HiddenField HFReferredID = (HiddenField)gvEmpReferredBy.Rows[e.RowIndex].FindControl("HFReferredID");

            TextBox txtRefererEmployeeNumber = (TextBox)gvEmpReferredBy.Rows[e.RowIndex].FindControl("txtRefererEmployeeNumber");
            TextBox txtRefererEmployeeName = (TextBox)gvEmpReferredBy.Rows[e.RowIndex].FindControl("txtRefererEmployeeName");
            if (txtRefererEmployeeName.Text != "" || txtRefererEmployeeNumber.Text != "")
            {
                if (txtRefererEmployeeNumber.Text != "")
                {
                    var ds1 = new DataSet();
                    var objHrManagement1 = new BL.HRManagement();
                    ds1 = objHrManagement1.SearchEmployee(txtRefererEmployeeNumber.Text);
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        ds = objHrManagement.EmployeeReferredBYDetails(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, txtRefererEmployeeNumber.Text, txtRefererEmployeeName.Text, BaseUserID, Convert.ToInt32(HFReferredID.Value));
                        gvEmpReferredBy.EditIndex = -1;
                        DisplayMessage(lblReferedBy, ds.Tables[0].Rows[0]["MessageId"].ToString());
                        FillgvEmpReferredBy();
                    }
                    else
                    {
                        lblReferedBy.Text = "Employee Number Doesn't Exist";
                    }
                }
                else
                {
                    ds = objHrManagement.EmployeeReferredBYDetails(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, txtRefererEmployeeNumber.Text, txtRefererEmployeeName.Text, BaseUserID, Convert.ToInt32(HFReferredID.Value));
                    gvEmpReferredBy.EditIndex = -1;
                    DisplayMessage(lblReferedBy, ds.Tables[0].Rows[0]["MessageId"].ToString());
                    FillgvEmpReferredBy();
                }
            }
            else
            {
                lblReferedBy.Text = "Please Enter Employee Number or Employee Name";
            }

        }

        catch (Exception ex)
        { }

    }

    protected void gvEmpReferredBy_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            HiddenField hfReferredID = (HiddenField)gvEmpReferredBy.FooterRow.FindControl("hfReferredID");
            TextBox txtRefererEmployeeNumber = (TextBox)gvEmpReferredBy.FooterRow.FindControl("txtRefererEmployeeNumber");
            TextBox txtRefererEmployeeName = (TextBox)gvEmpReferredBy.FooterRow.FindControl("txtRefererEmployeeName");
            TextBox txtLocationDesc = (TextBox)gvEmpReferredBy.FooterRow.FindControl("txtLocationDesc");
            TextBox txtDesignationDesc = (TextBox)gvEmpReferredBy.FooterRow.FindControl("txtDesignationDesc");
            TextBox txtDepartmentName = (TextBox)gvEmpReferredBy.FooterRow.FindControl("txtDepartmentName");

            if (txtRefererEmployeeName.Text != "" || txtRefererEmployeeNumber.Text != "")
            {
                if (e.CommandName == "AddNew")
                {
                    var toolkitScriptManager1 = (System.Web.UI.ScriptManager)Master.FindControl("ToolkitScriptManager1");
                    var ds = new DataSet();
                    var objHrManagement = new BL.HRManagement();

                    var strTimeFrom = string.Empty;
                    if (txtRefererEmployeeNumber.Text != "")
                    {
                        var ds1 = new DataSet();
                        var objHrManagement1 = new BL.HRManagement();
                        ds1 = objHrManagement1.SearchEmployee(txtRefererEmployeeNumber.Text);
                        if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                        {
                            if (txtRefererEmployeeNumber.Text != lblEmployeeNumberViewEmployeejobDetail.Text)
                            {
                                ds = objHrManagement.EmployeeReferredBYDetails(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, txtRefererEmployeeNumber.Text, txtRefererEmployeeName.Text, BaseUserID, Convert.ToInt32(hfReferredID.Value));
                                DisplayMessage(lblReferedBy, ds.Tables[0].Rows[0]["MessageId"].ToString());
                                FillgvEmpReferredBy();
                            }
                            else
                            {
                                lblReferedBy.Text = "You cann't refer urself";
                            }
                        }
                        else
                        {
                            lblReferedBy.Text = "Employee Number Doesn't Exist";
                        }
                    }
                    else
                    {
                        ds = objHrManagement.EmployeeReferredBYDetails(BaseCompanyCode, lblEmployeeNumberViewEmployeejobDetail.Text, txtRefererEmployeeNumber.Text, txtRefererEmployeeName.Text, BaseUserID, Convert.ToInt32(hfReferredID.Value));
                        DisplayMessage(lblReferedBy, ds.Tables[0].Rows[0]["MessageId"].ToString());
                        FillgvEmpReferredBy();

                    }

                }
            }
            else
            {
                lblReferedBy.Text = "Please Enter Employee Number or Employee Name";
            }
            if (e.CommandName == "Reset")
            {

                txtRefererEmployeeName.Text = "";
                txtRefererEmployeeNumber.Text = "";
                txtLocationDesc.Text = "";
                txtDesignationDesc.Text = "";
                txtDepartmentName.Text = "";


            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvEmpReferredBy_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        gvEmpReferredBy.EditIndex = -1;
        FillgvEmpReferredBy();

    }

    protected void gvEmpReferredBy_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        HiddenField ID = (HiddenField)gvEmpReferredBy.Rows[e.RowIndex].FindControl("HFReferredID");
        ds = objHrManagement.EmplyoyeeReferredByDetailDelete(Convert.ToInt32(ID.Value));

        DisplayMessage(lblReferedBy, ds.Tables[0].Rows[0]["MessageId"].ToString());
        gvEmpReferredBy.EditIndex = -1;
        FillgvEmpReferredBy();

    }
    protected void gvEmpReferredBy_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmpReferredBy.PageIndex = e.NewPageIndex;
        gvEmpReferredBy.EditIndex = -1;
        FillgvEmpReferredBy();

    }
    protected void imgSearchEmp_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        ImageButton imgSearchEmp = (ImageButton)sender;
        GridViewRow row = (GridViewRow)imgSearchEmp.NamingContainer;
        var ds = new DataSet();
        var objHrManagement = new BL.HRManagement();
        TextBox txtRefererEmployeeNumber = (TextBox)row.FindControl("txtRefererEmployeeNumber");
        TextBox txtLocationDesc = (TextBox)row.FindControl("txtLocationDesc");
        TextBox txtRefererEmployeeName = (TextBox)row.FindControl("txtRefererEmployeeName");
        TextBox txtDesignationDesc = (TextBox)row.FindControl("txtDesignationDesc");
        TextBox txtDepartmentName = (TextBox)row.FindControl("txtDepartmentName");
        if (txtRefererEmployeeNumber.Text != "")
        {
            ds = objHrManagement.SearchEmployee(txtRefererEmployeeNumber.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtRefererEmployeeName.Text = ds.Tables[0].Rows[0]["ReferEmployeeName"].ToString();
                txtLocationDesc.Text = ds.Tables[0].Rows[0]["LocationDesc"].ToString();
                txtDepartmentName.Text = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                txtDesignationDesc.Text = ds.Tables[0].Rows[0]["DesignationDesc"].ToString();

            }
            else
            {
                lblReferedBy.Text = "Employee Number Doesn't Exist";
                txtRefererEmployeeName.Text = "";
                txtLocationDesc.Text = "";
                txtDesignationDesc.Text = "";
                txtDepartmentName.Text = "";


            }
        }
        else
        {
            lblReferedBy.Text = "Please Enter Employee Number";
            txtRefererEmployeeName.Text = "";
            txtLocationDesc.Text = "";
            txtDesignationDesc.Text = "";
            txtDepartmentName.Text = "";


        }
    }
    #endregion
    #region Function related to Employee PFnESI
    protected void rblPF_CheckedChanged(object sender, EventArgs e)
    {
        if (rblPF.Checked == true)
        {

            EmployeeESI.Visible = false;
            EmployeePF.Visible = true;
            //if(txtUANNo.Text==null&& txtUANNo.Text=="")
            //{
            //    btnUpdatePF.Text = "Submit";
            //}
            //else
            //{
            //    btnUpdatePF.Visible = true;
            //}

        }

    }
    protected void rblESI_CheckedChanged(object sender, EventArgs e)
    {
        if (rblESI.Checked == true)
        {

            EmployeeESI.Visible = true;
            EmployeePF.Visible = false;
            //if (txtESINo.Text == null && txtESINo.Text == "")
            //{
            //    btnupdateESI.Text = "Submit";
            //}

        }
    }
    //protected void chkanyESI_CheckedChanged(object sender, EventArgs e)
    //{if(chkanyESI.Checked==true)
    //{ 
    //    lblOldESI.Visible = true;
    //    txtOldESI.Visible = true;
    //}
    //else
    //{
    //    lblOldESI.Visible = false;
    //    txtOldESI.Visible = false;
    //}
    //}
    //protected void chkUAN_CheckedChanged(object sender, EventArgs e)
    //{
    //    if(chkUAN.Checked==true)
    //    {
    //        lblOldUAN.Visible = true;
    //        txtOldUAN.Visible = true;
    //    }
    //    else
    //    {
    //        lblOldUAN.Visible = false;
    //        txtOldUAN.Visible = false;
    //    }
    //}
    protected void btnsubmitESI_Click(object sender, EventArgs e)
    {
        var objblUserManagement = new BL.HRManagement();
        DataTable dt = new DataTable();
        string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
        if (rblESI.Checked == true)
        {

            if (txtESINo.Text != null && txtESINo.Text != "")
            { 
                if(txtESINo.Text != txtOldESI.Text)
                { 
                //txtUANNo.Text = "";
                //txtOldUAN.Text = "";
                //txtaccountno.Text = "";
                //txtaccountnoold.Text = "";
                //txtregioncode.Text = "";
                //txtregionnoold.Text = "";
                //txtextensionno.Text = "";
                //txtestablishmentnoold.Text = "";
                //txtestablishmentno.Text = "";
                //txtofficecode.Text = "";
                //txtofficenoold.Text = "";
                //txtentensionnoold.Text = "";
                btnsubmitESI.Visible = false;
                btnupdateESI.Visible = true;
               // btnSubmitPF.Visible = false;
              //  btnUpdatePF.Visible = true;
             //   btnUpdatePF.Text = "Submit";
             //   btnupdateESI.Text = "Update";
                btnDeleteESI.Visible = true;
             //   btnDeletePF.Visible = false;
               
                DataSet ds = objblUserManagement.EmployeePFandESIInsert(BaseCompanyCode, empid, txtUANNo.Text, txtOldUAN.Text, txtESINo.Text, txtOldESI.Text, txtregioncode.Text, txtofficecode.Text, txtestablishmentno.Text, txtextensionno.Text, txtaccountno.Text, txtregionnoold.Text, txtofficenoold.Text, txtestablishmentnoold.Text, txtentensionnoold.Text, txtaccountnoold.Text, BaseUserID, "1");

                DisplayMessage(lblPFandESI, ds.Tables[0].Rows[0]["MessageId"].ToString());
                }
                else
            {
                lblPFandESI.Text = "ESI No. and Old ESI No. not to be same";
            }
            }
            else
            {
                lblPFandESI.Text = "Please Enter ESI No.";
            }

        }
        if (rblPF.Checked == true)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUANNo.Text, "[^0-9]"))
            {
                Show("UAN Number must be numeric");
                txtUANNo.Focus();
                txtUANNo.Text = "";
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(txtOldUAN.Text, "[^0-9]"))
            {
                Show("UAN Number must be numeric");
                txtOldUAN.Focus();
                txtOldUAN.Text = "";
                return;
            }
            if (txtUANNo.Text != null && txtUANNo.Text != "" && txtregioncode.Text != null && txtregioncode.Text != "" && txtofficecode.Text != null && txtofficecode.Text != "" && txtestablishmentno.Text != null && txtestablishmentno.Text != "" && txtaccountno.Text != null && txtaccountno.Text != "")
            {
                if (txtregionnoold.Text != "" || txtofficenoold.Text != "" || txtestablishmentnoold.Text != "" || txtaccountnoold.Text != "" || txtOldUAN.Text !="")
                {

                    if (txtregionnoold.Text != "" && txtregionnoold.Text != null && txtofficenoold.Text != "" && txtofficenoold.Text != null && txtestablishmentnoold.Text != null && txtestablishmentnoold.Text != "" && txtaccountnoold.Text != null && txtaccountnoold.Text != "" && txtOldUAN.Text != null && txtOldUAN.Text != "")
                    {

                        if (((txtregioncode.Text != txtregionnoold.Text) || (txtofficenoold.Text != txtofficecode.Text) ||(txtestablishmentnoold.Text != txtestablishmentno.Text) || (txtaccountnoold.Text != txtaccountno.Text)) && (txtUANNo.Text != txtOldUAN.Text))
                        {
                            //txtESINo.Text = "";
                            //txtOldESI.Text = "";
                            btnSubmitPF.Visible = false;
                            btnUpdatePF.Visible = true;
                          //  btnsubmitESI.Visible = false;
                         //   btnupdateESI.Visible = true;
                         //   btnupdateESI.Text = "Submit";
                         //   btnDeleteESI.Visible = false;
                            btnDeletePF.Visible = true;
                            DataSet ds = objblUserManagement.EmployeePFandESIInsert(BaseCompanyCode, empid, txtUANNo.Text, txtOldUAN.Text, txtESINo.Text, txtOldESI.Text, txtregioncode.Text, txtofficecode.Text, txtestablishmentno.Text, txtextensionno.Text, txtaccountno.Text, txtregionnoold.Text, txtofficenoold.Text, txtestablishmentnoold.Text, txtentensionnoold.Text, txtaccountnoold.Text, BaseUserID, "1");

                            DisplayMessage(lblPFandESI, ds.Tables[0].Rows[0]["MessageId"].ToString());

                        }
                        else
                        { lblPFandESI.Text = "New P.F.Number and Old P.F. Number not to be same "; }
                    }
                    else
                    { lblPFandESI.Text = "Please Enter Correct Old P.F.Number"; }

                }
                else
                {
                    //txtESINo.Text = "";
                    //txtOldESI.Text = "";
                    btnSubmitPF.Visible = false;
                    btnUpdatePF.Visible = true;
                //    btnsubmitESI.Visible = false;
                //    btnupdateESI.Visible = true;
                //    btnupdateESI.Text = "Submit";
               //     btnDeleteESI.Visible = false;
                    btnDeletePF.Visible = true;
                    DataSet ds1 = objblUserManagement.EmployeePFandESIInsert(BaseCompanyCode, empid, txtUANNo.Text, txtOldUAN.Text, txtESINo.Text, txtOldESI.Text, txtregioncode.Text, txtofficecode.Text, txtestablishmentno.Text, txtextensionno.Text, txtaccountno.Text, txtregionnoold.Text, txtofficenoold.Text, txtestablishmentnoold.Text, txtentensionnoold.Text, txtaccountnoold.Text, BaseUserID, "1");

                    DisplayMessage(lblPFandESI, ds1.Tables[0].Rows[0]["MessageId"].ToString());
                }
            }
            else
            {
                lblPFandESI.Text = "Please Enter Correct P.F.Number";
            }
        }
    }
    protected void btnupdateESI_Click(object sender, EventArgs e)
    {
        var objblUserManagement = new BL.HRManagement();
        DataTable dt = new DataTable();
        string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
        if (rblESI.Checked == true)
        {

            if (txtESINo.Text != null && txtESINo.Text != "")
            {
                if(txtESINo.Text != txtOldESI.Text)
                { 
                //txtUANNo.Text = "";
                //txtOldUAN.Text = "";
                //txtaccountno.Text = "";
                //txtaccountnoold.Text = "";
                //txtregioncode.Text = "";
                //txtregionnoold.Text = "";
                //txtextensionno.Text = "";
                //txtestablishmentnoold.Text = "";
                //txtestablishmentno.Text = "";
                //txtofficecode.Text = "";
                //txtofficenoold.Text = "";
                //txtentensionnoold.Text = "";
                btnsubmitESI.Visible = false;
                btnupdateESI.Visible = true;
             //   btnSubmitPF.Visible = false;
             //   btnUpdatePF.Visible = true;
             //   btnUpdatePF.Text = "Submit";
             //   btnupdateESI.Text = "Update";
                btnDeleteESI.Visible = true;
              //  btnDeletePF.Visible = false;
                DataSet ds = objblUserManagement.EmployeePFandESIInsert(BaseCompanyCode, empid, txtUANNo.Text, txtOldUAN.Text, txtESINo.Text, txtOldESI.Text, txtregioncode.Text, txtofficecode.Text, txtestablishmentno.Text, txtextensionno.Text, txtaccountno.Text, txtregionnoold.Text, txtofficenoold.Text, txtestablishmentnoold.Text, txtentensionnoold.Text, txtaccountnoold.Text, BaseUserID, "2");

                DisplayMessage(lblPFandESI, ds.Tables[0].Rows[0]["MessageId"].ToString());
                }
                else
                {
                    lblPFandESI.Text = "ESI No. and Old ESI No. not to be same";
                }
            }
            else
            {
                lblPFandESI.Text = "Please Enter ESI No.";
            }


        }
        if (rblPF.Checked == true)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUANNo.Text, "[^0-9]"))
            {
                Show("UAN Number must be numeric");
                txtUANNo.Focus();
                txtUANNo.Text = "";
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(txtOldUAN.Text, "[^0-9]"))
            {
                Show("UAN Number must be numeric");
                txtOldUAN.Focus();
                txtOldUAN.Text = "";
                return;
            }
            if (txtUANNo.Text != null && txtUANNo.Text != "" && txtregioncode.Text != null && txtregioncode.Text != "" && txtofficecode.Text != null && txtofficecode.Text != "" && txtestablishmentno.Text != null && txtestablishmentno.Text != "" && txtaccountno.Text != null && txtaccountno.Text != "")
            {
                if (txtregionnoold.Text != "" || txtofficenoold.Text != "" || txtestablishmentnoold.Text != "" || txtaccountnoold.Text != "")
                {

                    if (txtregionnoold.Text != "" && txtregionnoold.Text != null && txtofficenoold.Text != "" && txtofficenoold.Text != null && txtestablishmentnoold.Text != null && txtestablishmentnoold.Text != "" && txtaccountnoold.Text != null && txtaccountnoold.Text != "")
                    {
                          if (((txtregioncode.Text != txtregionnoold.Text) || (txtofficenoold.Text != txtofficecode.Text) ||(txtestablishmentnoold.Text != txtestablishmentno.Text) || (txtaccountnoold.Text != txtaccountno.Text)) && (txtUANNo.Text != txtOldUAN.Text))
                        {
                        //txtESINo.Text = "";
                        //txtOldESI.Text = "";
                        btnSubmitPF.Visible = false;
                        btnUpdatePF.Visible = true;
                     //   btnsubmitESI.Visible = false;
                   //     btnupdateESI.Visible = true;
                   //     btnupdateESI.Text = "Submit";
                  //      btnUpdatePF.Text = "Update";
                        btnDeletePF.Visible = true;
                   //     btnDeleteESI.Visible = false;
                        DataSet ds = objblUserManagement.EmployeePFandESIInsert(BaseCompanyCode, empid, txtUANNo.Text, txtOldUAN.Text, txtESINo.Text, txtOldESI.Text, txtregioncode.Text, txtofficecode.Text, txtestablishmentno.Text, txtextensionno.Text, txtaccountno.Text, txtregionnoold.Text, txtofficenoold.Text, txtestablishmentnoold.Text, txtentensionnoold.Text, txtaccountnoold.Text, BaseUserID, "2");

                        DisplayMessage(lblPFandESI, ds.Tables[0].Rows[0]["MessageId"].ToString());

                        }
                          else
                          { lblPFandESI.Text = "New P.F.Number and Old P.F. Number not to be same "; }

                    }
                    else
                    { lblPFandESI.Text = "Please Enter Correct Old P.F.Number"; }

                }
                else
                {
                    //txtESINo.Text = "";
                    //txtOldESI.Text = "";
                    btnSubmitPF.Visible = false;
                    btnUpdatePF.Visible = true;
                //    btnsubmitESI.Visible = false;
                //    btnupdateESI.Visible = true;
                //    btnupdateESI.Text = "Submit";
              //      btnUpdatePF.Text = "Update";
                    btnDeletePF.Visible = true;
                //    btnDeleteESI.Visible = false;
                    DataSet ds1 = objblUserManagement.EmployeePFandESIInsert(BaseCompanyCode, empid, txtUANNo.Text, txtOldUAN.Text, txtESINo.Text, txtOldESI.Text, txtregioncode.Text, txtofficecode.Text, txtestablishmentno.Text, txtextensionno.Text, txtaccountno.Text, txtregionnoold.Text, txtofficenoold.Text, txtestablishmentnoold.Text, txtentensionnoold.Text, txtaccountnoold.Text, BaseUserID, "2");

                    DisplayMessage(lblPFandESI, ds1.Tables[0].Rows[0]["MessageId"].ToString());
                }
            }
            else
            {
                lblPFandESI.Text = "Please Enter Correct P.F.Number";
            }
        }


    }
    protected void FillPFnESI()
    {
        try
        {

            var objblUserManagement = new BL.HRManagement();
            DataTable dt = new DataTable();
            string empid = lblEmployeeNumberViewEmployeejobDetail.Text;
            DataSet ds = objblUserManagement.EmployeePFandESIDetailGet(empid);

            dt = ds.Tables[0];
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["ESINo"].ToString() != null && dt.Rows[0]["ESINo"].ToString() != "")
                {
                    txtESINo.Text = dt.Rows[0]["ESINo"].ToString();
                    txtOldESI.Text = dt.Rows[0]["OldESINo"].ToString();
                    rblESI.Checked = true;
                    rblPF.Checked = false;
                    txtUANNo.Text = "";
                    txtOldUAN.Text = "";
                    txtaccountno.Text = "";
                    txtaccountnoold.Text = "";
                    txtregioncode.Text = "";
                    txtregionnoold.Text = "";
                    txtextensionno.Text = "";
                    txtestablishmentnoold.Text = "";
                    txtestablishmentno.Text = "";
                    txtofficecode.Text = "";
                    txtofficenoold.Text = "";
                    txtentensionnoold.Text = "";
                    btnsubmitESI.Visible = false;
                    btnupdateESI.Visible = true;
                    btnUpdatePF.Visible = true;
                    btnUpdatePF.Text = "Submit";
                    btnSubmitPF.Visible = false;
                    EmployeeESI.Visible = true;
                    EmployeePF.Visible = false;
                    btnDeleteESI.Visible = true;
                    btnDeletePF.Visible = false;

                }
                if (dt.Rows[0]["UANNo"].ToString() != null && dt.Rows[0]["PFRegion"].ToString() != null && dt.Rows[0]["UANNo"].ToString() != "" && dt.Rows[0]["PFRegion"].ToString() != "")
                {
                    txtESINo.Text = "";
                    txtOldESI.Text = "";
                    rblESI.Checked = false;
                    rblPF.Checked = true;
                    txtUANNo.Text = dt.Rows[0]["UANNo"].ToString();
                    txtOldUAN.Text = dt.Rows[0]["OldUANNo"].ToString();
                    txtaccountno.Text = dt.Rows[0]["PFAccount"].ToString();
                    txtaccountnoold.Text = dt.Rows[0]["PFAccountOld"].ToString();
                    txtregioncode.Text = dt.Rows[0]["PFRegion"].ToString();
                    txtregionnoold.Text = dt.Rows[0]["PFRegionOld"].ToString();
                    txtextensionno.Text = dt.Rows[0]["PFExtension"].ToString();
                    txtestablishmentnoold.Text = dt.Rows[0]["PFEstablishmentOld"].ToString();
                    txtestablishmentno.Text = dt.Rows[0]["PFEstablishment"].ToString();
                    txtofficecode.Text = dt.Rows[0]["PFOffice"].ToString();
                    txtofficenoold.Text = dt.Rows[0]["PFOfficeOld"].ToString();
                    txtentensionnoold.Text = dt.Rows[0]["PFExtensionOld"].ToString();
                    btnsubmitESI.Visible = false;
                    btnupdateESI.Visible = true;
                    btnupdateESI.Text = "Submit";
                    btnUpdatePF.Visible = true;
                    btnSubmitPF.Visible = false;
                    EmployeeESI.Visible = false;
                    EmployeePF.Visible = true;
                    btnDeleteESI.Visible = false;
                    btnDeletePF.Visible = true;

                }
            }
            else
            {
                txtESINo.Text = "";
                txtOldESI.Text = "";
                rblESI.Checked = false;
                rblPF.Checked = false;
                txtUANNo.Text = "";
                txtOldUAN.Text = "";
                txtaccountno.Text = "";
                txtaccountnoold.Text = "";
                txtregioncode.Text = "";
                txtregionnoold.Text = "";
                txtextensionno.Text = "";
                txtestablishmentnoold.Text = "";
                txtestablishmentno.Text = "";
                txtofficecode.Text = "";
                txtofficenoold.Text = "";
                txtentensionnoold.Text = "";
                btnsubmitESI.Visible = true;
                btnupdateESI.Visible = false;
                btnUpdatePF.Visible = false;
                btnSubmitPF.Visible = true;
                EmployeeESI.Visible = false;
                EmployeePF.Visible = false;


            }
        }
        catch (Exception e)
        { }
    }

    protected void btnDeleteESI_Click(object sender, EventArgs e)
    {
        var objblUserManagement = new BL.HRManagement();
        DataTable dt = new DataTable();
        string employeeNumber = lblEmployeeNumberViewEmployeejobDetail.Text;
        if (rblESI.Checked == true)
        {
            DataSet ds = objblUserManagement.EmployeePFandESIDetailDelete(employeeNumber, BaseCompanyCode);
            txtESINo.Text = "";
            txtOldESI.Text = "";
            DisplayMessage(lblPFandESI, ds.Tables[0].Rows[0]["MessageId"].ToString());
            btnsubmitESI.Visible = true;
            btnDeleteESI.Visible = false;
            btnupdateESI.Visible = false;
        }
        if (rblPF.Checked == true)
        {
            DataSet ds = objblUserManagement.EmployeePFandESIDetailDelete(employeeNumber, BaseCompanyCode);
            txtUANNo.Text = "";
            txtOldUAN.Text = "";
            txtaccountno.Text = "";
            txtaccountnoold.Text = "";
            txtregioncode.Text = "";
            txtregionnoold.Text = "";
            txtextensionno.Text = "";
            txtestablishmentnoold.Text = "";
            txtestablishmentno.Text = "";
            txtofficecode.Text = "";
            txtofficenoold.Text = "";
            txtentensionnoold.Text = "";
            DisplayMessage(lblPFandESI, ds.Tables[0].Rows[0]["MessageId"].ToString());
            btnDeletePF.Visible = false;
            btnUpdatePF.Visible = false;
            btnSubmitPF.Visible = true;
        }
    }
    private void ValidateFieldsPFnESI()
    {
        if (txtESINo != null)
        {
            txtESINo.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            txtESINo.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        }
        if (txtOldESI != null)
        {
            txtOldESI.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            txtOldESI.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        }
        if (txtregioncode != null)
        {
            txtregioncode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtregioncode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (txtofficecode != null)
        {
            txtofficecode.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtofficecode.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (txtestablishmentno != null)
        {
            txtestablishmentno.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            txtestablishmentno.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        }
        if (txtextensionno != null)
        {
            txtextensionno.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtextensionno.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (txtaccountno != null)
        {
            txtaccountno.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtaccountno.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (txtregionnoold != null)
        {
            txtregionnoold.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtregionnoold.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (txtofficenoold != null)
        {
            txtofficenoold.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
            txtofficenoold.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionString + ");");
        }
        if (txtestablishmentnoold != null)
        {
            txtestablishmentnoold.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtestablishmentnoold.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (txtentensionnoold != null)
        {
            txtentensionnoold.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtentensionnoold.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }
        if (txtaccountnoold != null)
        {
            txtaccountnoold.Attributes.Add("onkeyup", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
            txtaccountnoold.Attributes.Add("onblur", "javascript:validateStringWithExpression(this," + Resources.Resource.ValidationExpressionFloat + ");");
        }




    }
    #endregion
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Request.UrlReferrer != null)
        {
            Response.Redirect(urlReferrer, false);
        }
    }
}
