using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class AssetManagement_AssetSchedulingNew : BasePage
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
                //txtClientCode.Text = DateTime.Now.Month.ToString("00");
                ddlMonth.SelectedValue = DateTime.Now.ToString("MM");

                FillddlAreaId();
                FillddlAsmt();
                FillddlPost();
                for (int i = 2018; i < 2036; i++)
                {
                    ddlYear.Items.Add("" + i + "");
                }
                ddlYear.SelectedValue = DateTime.Now.ToString("YYYY");
                FillddlWeek();
                //    txtServiceDate.Attributes.Add("readonly", "readonly");
                //  txtServiceDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                //    txtToDate.Attributes.Add("readonly", "readonly");
                //    txtToDate.Text = Convert.ToDateTime(txtServiceDate.Text).AddDays(6).ToString("dd-MMM-yyyy");
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }

        }
    }
    #region Binding
    /// <summary>
    /// Fillddls the area identifier.
    /// </summary>
    protected void FillddlAreaId()
    {
        ListItem li;

        var objSale = new BL.OperationManagement();
        DataSet dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();

            li = new ListItem { Text = Resources.Resource.All, Value = @"ALL" };
            ddlAreaID.Items.Insert(0, li);

            FillddlClient();
        }
        if (ddlAreaID.Text == "")
        {
            li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlAreaID.Items.Add(li);
        }
    }
    protected void FillddlWeek()
    {
        ListItem li;
        DataSet ds = new DataSet();
        BL.AssetScheduling objAS = new BL.AssetScheduling();
        ds = objAS.GetWeeks((BaseLocationAutoID), ddlMonth.SelectedValue, ddlYear.SelectedValue);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlWeek.DataSource = ds.Tables[0];
            ddlWeek.DataValueField = "Date";
            ddlWeek.DataTextField = "Week";
            ddlWeek.DataBind();
            //txtServiceDate.Text = ds.Tables[0].Columns["StartDate"].ToString();
            //txtToDate.Text = ds.Tables[0].Columns["EndDate"].ToString();

        }
        if (ddlWeek.Text == "")
        {
            li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlWeek.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillddls the client.
    /// </summary>
    protected void FillddlClient()
    {
        ddlClient.Items.Clear();
        ddlAsmt.Items.Clear();
        var objSale = new BL.Sales();
        var ds = BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower() ? objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID) : objSale.ClientsMappedToLocationGet(BaseLocationAutoID, ddlAreaID.SelectedItem.Value, txtClientCode.Text, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientCodeName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();
            FillddlAsmt();
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlClient.Items.Add(li);
            ddlAsmt.Items.Add(li);
        }
    }
    /// <summary>
    /// Fillddls the asmt.
    /// </summary>
    protected void FillddlAsmt()
    {
        ddlAsmt.Items.Clear();
        var objSale = new BL.Sales();
        DataSet ds = objSale.ClientDetailsGet(BaseLocationAutoID, ddlClient.SelectedItem.Value, ddlAreaID.SelectedItem.Value, BaseUserEmployeeNumber, BaseUserIsAreaIncharge, DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            var dv = new DataView(ds.Tables[0]) { RowFilter = "IsBillable = False" };
            if (dv.Count > 0)
            {
                ddlAsmt.DataSource = dv.ToTable();
                ddlAsmt.DataTextField = "AsmtAddress";
                ddlAsmt.DataValueField = "AsmtId";
                ddlAsmt.DataBind();
                FillddlPost();
            }
            else
            {
                var li = new ListItem
                {
                    Text = @Resources.Resource.NoDataToShow,
                    Value = string.Empty
                };
                ddlAsmt.Items.Add(li);
                ddlPost.Items.Add(li);
            }
        }
        else
        {
            var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
            ddlAsmt.Items.Add(li);
            ddlPost.Items.Add(li);
        }
    }

    /// <summary>
    /// Fillddls the post.
    /// </summary>
    /// <param name="ddlPost">The DDL post.</param>
    protected void FillddlPost()
    {
        var objSale = new BL.Sales();
        DataSet ds = objSale.PostGetAll(ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlPost.DataSource = ds.Tables[0];
            ddlPost.DataTextField = "PostDesc";
            ddlPost.DataValueField = "PostAutoId";
            ddlPost.DataBind();
        }
        else
        {
            var li = new ListItem { Text = Resources.Resource.AddNew, Value = string.Empty };
            ddlPost.Items.Add(li);
        }
    }
    #endregion
    protected void btnProceed_Click(object sender, EventArgs e)
    {
        string[] ScheduleDate = ddlWeek.SelectedValue.Split('/');
        txtServiceDate.Text = ScheduleDate[0].ToString();
        txtToDate.Text = ScheduleDate[1].ToString();
        //if (DateTime.Parse(txtToDate.Text) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
        //{
        FillgvAssetScheduling();
        //    btnAutoFillSchedule.Visible = true;
        //}
        //else
        //{
        //    lblErrorMsg.Text = "You cann't schedule for this week !!";
        //    gvAssetScheduling.Visible = false;
        //}
    }
    private void FillgvAssetScheduling()
    {
        DataSet ds = new DataSet();
        BL.AssetScheduling objAS = new BL.AssetScheduling();
        if (ddlClient.SelectedItem.Value != string.Empty && ddlAsmt.SelectedItem.Value != string.Empty && ddlPost.SelectedItem.Value != string.Empty && txtServiceDate.Text != string.Empty)
        {
            lblErrorMsg.Text = String.Empty;
            ds = objAS.AssetScheduleGetNew(BaseLocationAutoID, ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value, ddlPost.SelectedItem.Value, txtServiceDate.Text, txtToDate.Text);
            DataTable dsResult = ds.Tables[1].Copy();
            var ts = DateTime.Parse(txtToDate.Text).Subtract(DateTime.Parse(txtServiceDate.Text));
            var t = int.Parse(ts.Days.ToString()) + 1;
            var dttempDate = DateTime.Parse(txtServiceDate.Text);
            for (int j = 0; j < t; j++)
            {
                string strColName = Convert.ToString(dttempDate.ToString(Resources.Resource.ScheduleDefaultDateFormat));
                var strColNo = new DataColumn(strColName);
                dsResult.Columns.Add(strColNo);
                dttempDate = dttempDate.AddDays(double.Parse("1"));
            }
            dsResult.Columns.Add("AssetWoNo");
            dsResult.Columns.Add("AssetWoLineNo");
            dsResult.Columns.Add("AssetAutoId");

            for (var j = 0; j < dsResult.Rows.Count; j++)
            {
                var dv1 = new DataView(ds.Tables[0]);
                var filterCondition = "[AssetCode]='" + (dsResult.Rows[j]["AssetCode"]) + "' AND " + "[AssetServiceTypeAutoId]='" + dsResult.Rows[j]["AssetServiceTypeAutoId"] + "'";
                dv1.RowFilter = filterCondition;

                foreach (DataRowView drV1 in dv1)
                {
                    var str = DateTime.Parse(drV1["DutyDate"].ToString()).ToString(Resources.Resource.ScheduleDefaultDateFormat);
                    if ((dsResult.Rows[j]["AssetCode"].ToString() == drV1["AssetCode"].ToString()) && (dsResult.Rows[j]["AssetServiceTypeAutoId"].ToString() == drV1["AssetServiceTypeAutoId"].ToString()))
                    {
                        dsResult.Rows[j]["AssetWoNo"] = drV1["AssetWoNo"].ToString();
                        dsResult.Rows[j]["AssetWoLineNo"] = drV1["AssetWoLineNo"].ToString();
                        dsResult.Rows[j]["AssetAutoId"] = drV1["AssetAutoId"].ToString();
                        dsResult.Rows[j][DateTime.Parse(str).ToString(Resources.Resource.ScheduleDefaultDateFormat).ToLower()] = drV1["EmployeeNumber"].ToString() + "/" + drV1["EmployeeName"].ToString() + "/" + drV1["SchFromTime"].ToString() + "/" + drV1["SchToTime"].ToString() + "/" + drV1["Assetscheduleautoid"].ToString();
                    }
                }
            }


            for (var k = 4; k < 11; k++)
            {
                dsResult.Columns[k].ColumnName = k.ToString();

            }
            dsResult.Columns.Add("40");
            dsResult.Columns.Add("41");
            dsResult.Columns.Add("42");
            dsResult.Columns.Add("43");

            dsResult.Columns.Add("50");
            dsResult.Columns.Add("51");
            dsResult.Columns.Add("52");
            dsResult.Columns.Add("53");

            dsResult.Columns.Add("60");
            dsResult.Columns.Add("61");
            dsResult.Columns.Add("62");
            dsResult.Columns.Add("63");

            dsResult.Columns.Add("70");
            dsResult.Columns.Add("71");
            dsResult.Columns.Add("72");
            dsResult.Columns.Add("73");

            dsResult.Columns.Add("80");
            dsResult.Columns.Add("81");
            dsResult.Columns.Add("82");
            dsResult.Columns.Add("83");

            dsResult.Columns.Add("90");
            dsResult.Columns.Add("91");
            dsResult.Columns.Add("92");
            dsResult.Columns.Add("93");

            dsResult.Columns.Add("100");
            dsResult.Columns.Add("101");
            dsResult.Columns.Add("102");
            dsResult.Columns.Add("103");

            // For storing AssetScheduleAutoID against each day
            dsResult.Columns.Add("401");
            dsResult.Columns.Add("501");
            dsResult.Columns.Add("601");
            dsResult.Columns.Add("701");
            dsResult.Columns.Add("801");
            dsResult.Columns.Add("901");
            dsResult.Columns.Add("1001");

            DataTable dt = dsResult.Copy();
            string value = "";
            var row = dt.Rows.Count;

            for (int i = 0; i < row; i++)
            {
                for (int j = 4; j < 11; j++)
                {
                    value = dt.Rows[i][j].ToString();
                    if (value != "")
                    {

                        if (j == 4)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][14] = splitPipeValue[0].ToString();
                            dt.Rows[i][15] = splitPipeValue[1].ToString();
                            dt.Rows[i][16] = splitPipeValue[2].ToString();
                            dt.Rows[i][17] = splitPipeValue[3].ToString();
                            dt.Rows[i][42] = splitPipeValue[4].ToString();
                        }
                        if (j == 5)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][18] = splitPipeValue[0].ToString();
                            dt.Rows[i][19] = splitPipeValue[1].ToString();
                            dt.Rows[i][20] = splitPipeValue[2].ToString();
                            dt.Rows[i][21] = splitPipeValue[3].ToString();
                            dt.Rows[i][43] = splitPipeValue[4].ToString();
                        }
                        if (j == 6)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][22] = splitPipeValue[0].ToString();
                            dt.Rows[i][23] = splitPipeValue[1].ToString();
                            dt.Rows[i][24] = splitPipeValue[2].ToString();
                            dt.Rows[i][25] = splitPipeValue[3].ToString();
                            dt.Rows[i][44] = splitPipeValue[4].ToString();
                        }
                        if (j == 7)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][26] = splitPipeValue[0].ToString();
                            dt.Rows[i][27] = splitPipeValue[1].ToString();
                            dt.Rows[i][28] = splitPipeValue[2].ToString();
                            dt.Rows[i][29] = splitPipeValue[3].ToString();
                            dt.Rows[i][45] = splitPipeValue[4].ToString();

                        }
                        if (j == 8)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][30] = splitPipeValue[0].ToString();
                            dt.Rows[i][31] = splitPipeValue[1].ToString();
                            dt.Rows[i][32] = splitPipeValue[2].ToString();
                            dt.Rows[i][33] = splitPipeValue[3].ToString();
                            dt.Rows[i][46] = splitPipeValue[4].ToString();
                        }
                        if (j == 9)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][34] = splitPipeValue[0].ToString();
                            dt.Rows[i][35] = splitPipeValue[1].ToString();
                            dt.Rows[i][36] = splitPipeValue[2].ToString();
                            dt.Rows[i][37] = splitPipeValue[3].ToString();
                            dt.Rows[i][47] = splitPipeValue[4].ToString();
                        }
                        if (j == 10)
                        {
                            string[] splitPipeValue = value.Split('/');
                            dt.Rows[i][38] = splitPipeValue[0].ToString();
                            dt.Rows[i][39] = splitPipeValue[1].ToString();
                            dt.Rows[i][40] = splitPipeValue[2].ToString();
                            dt.Rows[i][41] = splitPipeValue[3].ToString();
                            dt.Rows[i][48] = splitPipeValue[4].ToString();
                        }

                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                gvAssetScheduling.Visible = true;
                gvAssetScheduling.DataSource = dt;
                gvAssetScheduling.DataBind();
                btnAutoFillSchedule.Visible = true;
            }
            else
            {
                lblErrorMsg.Text = Resources.Resource.NoRecordFound;
                gvAssetScheduling.Visible = false;
                btnAutoFillSchedule.Visible = false;
            }
        }


    }
    protected void gvAssetScheduling_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        if (e.Row.RowType == DataControlRowType.Header)
        {

            var lblFirstDate = (Label)e.Row.FindControl("lblFirstDate");
            if (lblFirstDate != null)
            {
                lblFirstDate.Text = txtServiceDate.Text + " [ " + Convert.ToDateTime(txtServiceDate.Text).DayOfWeek.ToString() + " ]";
            }
            var lblSecondDate = (Label)e.Row.FindControl("lblSecondDate");
            if (lblSecondDate != null)
            {
                var SDay = Convert.ToDateTime(txtServiceDate.Text).AddDays(1).ToString("dd-MMM-yyyy");
                lblSecondDate.Text = Convert.ToDateTime(txtServiceDate.Text).AddDays(1).ToString("dd-MMM-yyyy") + " [ " + Convert.ToDateTime(SDay).DayOfWeek.ToString() + " ]";
            }
            var lblThirdDate = (Label)e.Row.FindControl("lblThirdDate");
            if (lblThirdDate != null)
            {
                var TDay = Convert.ToDateTime(txtServiceDate.Text).AddDays(2).ToString("dd-MMM-yyyy");
                lblThirdDate.Text = Convert.ToDateTime(txtServiceDate.Text).AddDays(2).ToString("dd-MMM-yyyy") + " [ " + Convert.ToDateTime(TDay).DayOfWeek.ToString() + " ]";
            }
            var lblFourthDate = (Label)e.Row.FindControl("lblFourthDate");
            if (lblFourthDate != null)
            {
                var FDay = Convert.ToDateTime(txtServiceDate.Text).AddDays(3).ToString("dd-MMM-yyyy");
                lblFourthDate.Text = Convert.ToDateTime(txtServiceDate.Text).AddDays(3).ToString("dd-MMM-yyyy") + " [ " + Convert.ToDateTime(FDay).DayOfWeek.ToString() + " ]";
            }
            var lblFifthDate = (Label)e.Row.FindControl("lblFifthDate");
            if (lblFifthDate != null)
            {
                var FiDay = Convert.ToDateTime(txtServiceDate.Text).AddDays(4).ToString("dd-MMM-yyyy");
                lblFifthDate.Text = Convert.ToDateTime(txtServiceDate.Text).AddDays(4).ToString("dd-MMM-yyyy") + " [ " + Convert.ToDateTime(FiDay).DayOfWeek.ToString() + " ]";
            }
            var lblSixthDate = (Label)e.Row.FindControl("lblSixthDate");
            if (lblSixthDate != null)
            {
                var SixDay = Convert.ToDateTime(txtServiceDate.Text).AddDays(5).ToString("dd-MMM-yyyy");
                lblSixthDate.Text = Convert.ToDateTime(txtServiceDate.Text).AddDays(5).ToString("dd-MMM-yyyy") + " [ " + Convert.ToDateTime(SixDay).DayOfWeek.ToString() + " ]";
            }
            var lblSeventhDate = (Label)e.Row.FindControl("lblSeventhDate");
            if (lblSeventhDate != null)
            {
                var SevDay = Convert.ToDateTime(txtServiceDate.Text).AddDays(6).ToString("dd-MMM-yyyy");
                lblSeventhDate.Text = Convert.ToDateTime(txtServiceDate.Text).AddDays(6).ToString("dd-MMM-yyyy") + " [ " + Convert.ToDateTime(SevDay).DayOfWeek.ToString() + " ]";
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txt40 = (TextBox)e.Row.FindControl("txt40");
            var txt41 = (TextBox)e.Row.FindControl("txt41");
            var txt42 = (TextBox)e.Row.FindControl("txt42");
            var txt43 = (TextBox)e.Row.FindControl("txt43");
            if (txt42.Text != "")
            {
                txt40.Enabled = true;
                txt41.Enabled = false;
                txt42.Enabled = true;
                txt43.Enabled = true;
                txt40.BackColor = Color.White;
                txt41.BackColor = Color.White;
                txt42.BackColor = Color.White;
                txt43.BackColor = Color.White;
                SetTimeValidationToTextBox(txt42);
                SetTimeValidationToTextBox(txt43);
            }
            else
            {
                txt40.Enabled = false;
                txt40.BackColor = Color.Gray;
                txt41.Enabled = false;
                txt41.BackColor = Color.Gray;
                txt42.Enabled = false;
                txt42.BackColor = Color.Gray;
                txt43.Enabled = false;
                txt43.BackColor = Color.Gray;
            }

            var txt50 = (TextBox)e.Row.FindControl("txt50");
            var txt51 = (TextBox)e.Row.FindControl("txt51");
            var txt52 = (TextBox)e.Row.FindControl("txt52");
            var txt53 = (TextBox)e.Row.FindControl("txt53");
            if (txt52.Text != "")
            {
                txt50.Enabled = true;
                txt50.BackColor = Color.White;
                txt51.Enabled = false;
                txt52.Enabled = true;
                txt53.Enabled = true;
                txt51.BackColor = Color.White;
                txt52.BackColor = Color.White;
                txt53.BackColor = Color.White;
                SetTimeValidationToTextBox(txt52);
                SetTimeValidationToTextBox(txt53);
            }
            else
            {
                txt50.Enabled = false;
                txt50.BackColor = Color.Gray;
                txt51.Enabled = false;
                txt51.BackColor = Color.Gray;
                txt52.Enabled = false;
                txt52.BackColor = Color.Gray;
                txt53.Enabled = false;
                txt53.BackColor = Color.Gray;
            }

            var txt60 = (TextBox)e.Row.FindControl("txt60");
            var txt61 = (TextBox)e.Row.FindControl("txt61");
            var txt62 = (TextBox)e.Row.FindControl("txt62");
            var txt63 = (TextBox)e.Row.FindControl("txt63");
            if (txt62.Text != "")
            {
                txt60.Enabled = true;
                txt61.Enabled = false;
                txt62.Enabled = true;
                txt63.Enabled = true;
                txt60.BackColor = Color.White;
                txt61.BackColor = Color.White;
                txt62.BackColor = Color.White;
                txt63.BackColor = Color.White;
                SetTimeValidationToTextBox(txt62);
                SetTimeValidationToTextBox(txt63);
            }
            else
            {
                txt60.Enabled = false;
                txt60.BackColor = Color.Gray;
                txt61.Enabled = false;
                txt61.BackColor = Color.Gray;
                txt62.Enabled = false;
                txt62.BackColor = Color.Gray;
                txt63.Enabled = false;
                txt63.BackColor = Color.Gray;
            }

            var txt70 = (TextBox)e.Row.FindControl("txt70");
            var txt71 = (TextBox)e.Row.FindControl("txt71");
            var txt72 = (TextBox)e.Row.FindControl("txt72");
            var txt73 = (TextBox)e.Row.FindControl("txt73");
            if (txt72.Text != "")
            {
                txt70.Enabled = true;
                txt71.Enabled = false;
                txt72.Enabled = true;
                txt73.Enabled = true;
                txt70.BackColor = Color.White;
                txt71.BackColor = Color.White;
                txt72.BackColor = Color.White;
                txt73.BackColor = Color.White;
                SetTimeValidationToTextBox(txt72);
                SetTimeValidationToTextBox(txt73);
            }
            else
            {
                txt70.Enabled = false;
                txt70.BackColor = Color.Gray;
                txt71.Enabled = false;
                txt71.BackColor = Color.Gray;
                txt72.Enabled = false;
                txt72.BackColor = Color.Gray;
                txt73.Enabled = false;
                txt73.BackColor = Color.Gray;
            }

            var txt80 = (TextBox)e.Row.FindControl("txt80");
            var txt81 = (TextBox)e.Row.FindControl("txt81");
            var txt82 = (TextBox)e.Row.FindControl("txt82");
            var txt83 = (TextBox)e.Row.FindControl("txt83");
            if (txt82.Text != "")
            {
                txt80.Enabled = true;
                txt81.Enabled = false;
                txt82.Enabled = true;
                txt83.Enabled = true;
                txt80.BackColor = Color.White;
                txt81.BackColor = Color.White;
                txt82.BackColor = Color.White;
                txt83.BackColor = Color.White;
                SetTimeValidationToTextBox(txt82);
                SetTimeValidationToTextBox(txt83);
            }
            else
            {
                txt80.Enabled = false;
                txt80.BackColor = Color.Gray;
                txt81.Enabled = false;
                txt81.BackColor = Color.Gray;
                txt82.Enabled = false;
                txt82.BackColor = Color.Gray;
                txt83.Enabled = false;
                txt83.BackColor = Color.Gray;
            }

            var txt90 = (TextBox)e.Row.FindControl("txt90");
            var txt91 = (TextBox)e.Row.FindControl("txt91");
            var txt92 = (TextBox)e.Row.FindControl("txt92");
            var txt93 = (TextBox)e.Row.FindControl("txt93");
            if (txt92.Text != "")
            {
                txt90.Enabled = true;
                txt91.Enabled = false;
                txt92.Enabled = true;
                txt93.Enabled = true;
                txt90.BackColor = Color.White;
                txt91.BackColor = Color.White;
                txt92.BackColor = Color.White;
                txt93.BackColor = Color.White;
                SetTimeValidationToTextBox(txt92);
                SetTimeValidationToTextBox(txt93);
            }
            else
            {
                txt90.Enabled = false;
                txt90.BackColor = Color.Gray;
                txt91.Enabled = false;
                txt91.BackColor = Color.Gray;
                txt92.Enabled = false;
                txt92.BackColor = Color.Gray;
                txt93.Enabled = false;
                txt93.BackColor = Color.Gray;
            }

            var txt100 = (TextBox)e.Row.FindControl("txt100");
            var txt101 = (TextBox)e.Row.FindControl("txt101");
            var txt102 = (TextBox)e.Row.FindControl("txt102");
            var txt103 = (TextBox)e.Row.FindControl("txt103");
            if (txt102.Text != "")
            {
                txt100.Enabled = true;
                txt101.Enabled = false;
                txt102.Enabled = true;
                txt103.Enabled = true;
                txt100.BackColor = Color.White;
                txt101.BackColor = Color.White;
                txt102.BackColor = Color.White;
                txt103.BackColor = Color.White;
                SetTimeValidationToTextBox(txt102);
                SetTimeValidationToTextBox(txt103);
            }
            else
            {
                txt100.Enabled = false;
                txt100.BackColor = Color.Gray;
                txt101.Enabled = false;
                txt101.BackColor = Color.Gray;
                txt102.Enabled = false;
                txt102.BackColor = Color.Gray;
                txt103.Enabled = false;
                txt103.BackColor = Color.Gray;
            }

        }



    }
    protected void txtClientCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            ddlClient.SelectedValue = txtClientCode.Text;
            FillddlAsmt();
        }
        catch (Exception) { }
    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClientCode.Text = string.Empty;
        FillddlAsmt();
    }
    protected void ddlAsmt_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlPost();
    }
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtClientCode.Text = string.Empty;
        FillddlClient();
    }
    protected void txtServiceDate_TextChanged(object sender, EventArgs e)
    {
        txtToDate.Text = Convert.ToDateTime(txtServiceDate.Text).AddDays(6).ToString("dd-MMM-yyyy");
    }
    protected void gvAssetScheduling_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvAssetScheduling.PageIndex = e.NewPageIndex;
        gvAssetScheduling.EditIndex = -1;
        FillgvAssetScheduling();
    }
    protected void gvAssetScheduling_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);

        var txt40 = (TextBox)row.FindControl("txt40");
        var txt41 = (TextBox)row.FindControl("txt41");
        var txt42 = (TextBox)row.FindControl("txt42");
        var txt43 = (TextBox)row.FindControl("txt43");
        var txt50 = (TextBox)row.FindControl("txt50");
        var txt51 = (TextBox)row.FindControl("txt51");
        var txt52 = (TextBox)row.FindControl("txt52");
        var txt53 = (TextBox)row.FindControl("txt53");
        var txt60 = (TextBox)row.FindControl("txt60");
        var txt61 = (TextBox)row.FindControl("txt61");
        var txt62 = (TextBox)row.FindControl("txt62");
        var txt63 = (TextBox)row.FindControl("txt63");
        var txt70 = (TextBox)row.FindControl("txt70");
        var txt71 = (TextBox)row.FindControl("txt71");
        var txt72 = (TextBox)row.FindControl("txt72");
        var txt73 = (TextBox)row.FindControl("txt73");
        var txt80 = (TextBox)row.FindControl("txt80");
        var txt81 = (TextBox)row.FindControl("txt81");
        var txt82 = (TextBox)row.FindControl("txt82");
        var txt83 = (TextBox)row.FindControl("txt83");
        var txt90 = (TextBox)row.FindControl("txt90");
        var txt91 = (TextBox)row.FindControl("txt91");
        var txt92 = (TextBox)row.FindControl("txt92");
        var txt93 = (TextBox)row.FindControl("txt93");
        var txt100 = (TextBox)row.FindControl("txt100");
        var txt101 = (TextBox)row.FindControl("txt101");
        var txt102 = (TextBox)row.FindControl("txt102");
        var txt103 = (TextBox)row.FindControl("txt103");
        //var hfAssetScheduleAutoId = (HiddenField)row.FindControl("hfAssetScheduleAutoId");
        var hfAssetWoNo = (HiddenField)row.FindControl("hfAssetWoNo");
        var hfAssetWoLineNo = (HiddenField)row.FindControl("hfAssetWoLineNo");
        var hfAssetAutoId = (HiddenField)row.FindControl("hfAssetAutoId");
        var hfAssetServiceTypeAutoId = (HiddenField)row.FindControl("hfAssetServiceTypeAutoId");

        if (e.CommandName == "Add")
        {

        }

        if (e.CommandName == "Reset")
        {
            txt40.Text = string.Empty;
            txt41.Text = string.Empty;
            txt50.Text = string.Empty;
            txt51.Text = string.Empty;
            txt60.Text = string.Empty;
            txt61.Text = string.Empty;
            txt70.Text = string.Empty;
            txt71.Text = string.Empty;
            txt80.Text = string.Empty;
            txt81.Text = string.Empty;
            txt90.Text = string.Empty;
            txt91.Text = string.Empty;
            txt100.Text = string.Empty;
            txt101.Text = string.Empty;

        }
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
    protected void txt40_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        TextBox txt41 = (TextBox)gvRow.FindControl("txt41");
        TextBox txt40 = (TextBox)gvRow.FindControl("txt40");
        TextBox txt42 = (TextBox)gvRow.FindControl("txt42");
        TextBox txt43 = (TextBox)gvRow.FindControl("txt43");
        var hfAssetScheduleAutoId = "";
        HiddenField hfAssetWoNo = (HiddenField)gvRow.FindControl("hfAssetWoNo");
        HiddenField hfAssetWoLineNo = (HiddenField)gvRow.FindControl("hfAssetWoLineNo");
        HiddenField hfAssetAutoId = (HiddenField)gvRow.FindControl("hfAssetAutoId");
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvRow.FindControl("hfAssetServiceTypeAutoId");
        HiddenField hfFromTime42 = (HiddenField)gvRow.FindControl("hfFromTime42");
        HiddenField hfToTime43 = (HiddenField)gvRow.FindControl("hfToTime43");
        HiddenField hfAssetId4 = (HiddenField)gvRow.FindControl("hfAssetId4");

        var objAS = new BL.AssetScheduling();
        if (txt40.Text != string.Empty && txt42.Text != string.Empty && txt43.Text != string.Empty)
        {
            if (txt41.Text == "")
            {
                hfAssetScheduleAutoId = "0";
            }
            else
            {
                hfAssetScheduleAutoId = hfAssetId4.Value;
            }
            if (DateTime.Parse(txtServiceDate.Text) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
            {

                DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.ToString(), BaseLocationAutoID, ddlClient.SelectedItem.Value,
                    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
                    hfAssetServiceTypeAutoId.Value, "", txtServiceDate.Text, hfFromTime42.Value, hfToTime43.Value, txt40.Text,
                    txt42.Text, txt43.Text, BaseUserID);
                FillgvAssetScheduling();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());

                }
            }
            else
            {
                lblErrorMsg.Text = "You cann't schedule for this Date as Date must be greater than or equal to current date !!";
                txt40.Text = "";

            }
        }
        else
        {
            lblErrorMsg.Text = "Employee No. , From Time & To Time cann't be blank !!";

        }

    }
    protected void txt50_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        TextBox txt41 = (TextBox)gvRow.FindControl("txt51");
        TextBox txt40 = (TextBox)gvRow.FindControl("txt50");
        TextBox txt42 = (TextBox)gvRow.FindControl("txt52");
        TextBox txt43 = (TextBox)gvRow.FindControl("txt53");
        var hfAssetScheduleAutoId = "";
        HiddenField hfAssetWoNo = (HiddenField)gvRow.FindControl("hfAssetWoNo");
        HiddenField hfAssetWoLineNo = (HiddenField)gvRow.FindControl("hfAssetWoLineNo");
        HiddenField hfAssetAutoId = (HiddenField)gvRow.FindControl("hfAssetAutoId");
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvRow.FindControl("hfAssetServiceTypeAutoId");
        HiddenField hfFromTime42 = (HiddenField)gvRow.FindControl("hfFromTime52");
        HiddenField hfToTime43 = (HiddenField)gvRow.FindControl("hfToTime53");
        HiddenField hfAssetId5 = (HiddenField)gvRow.FindControl("hfAssetId5");

        var objAS = new BL.AssetScheduling();
        if (txt40.Text != string.Empty && txt42.Text != string.Empty && txt43.Text != string.Empty)
        {
            if (txt41.Text == "")
            {
                hfAssetScheduleAutoId = "0";
            }
            else
            {
                hfAssetScheduleAutoId = hfAssetId5.Value;
            }

            if (DateTime.Parse(Convert.ToDateTime(txtServiceDate.Text).AddDays(1).ToString("dd-MMM-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
            {
                DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.ToString(), BaseLocationAutoID, ddlClient.SelectedItem.Value,
                    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
                    hfAssetServiceTypeAutoId.Value, "", Convert.ToDateTime(txtServiceDate.Text).AddDays(1).ToString("dd-MMM-yyyy"), hfFromTime42.Value, hfToTime43.Value, txt40.Text,
                    txt42.Text, txt43.Text, BaseUserID);
                FillgvAssetScheduling();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
                lblErrorMsg.Text = "You cann't schedule for this Date as Date must be greater than or equal to current date !!";
                txt40.Text = "";

            }
        }
        else
        {
            lblErrorMsg.Text = "Employee No. , From Time & To Time cann't be blank !!";

        }
    }
    protected void txt60_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        TextBox txt41 = (TextBox)gvRow.FindControl("txt61");
        TextBox txt40 = (TextBox)gvRow.FindControl("txt60");
        TextBox txt42 = (TextBox)gvRow.FindControl("txt62");
        TextBox txt43 = (TextBox)gvRow.FindControl("txt63");
        var hfAssetScheduleAutoId = "";
        HiddenField hfAssetWoNo = (HiddenField)gvRow.FindControl("hfAssetWoNo");
        HiddenField hfAssetWoLineNo = (HiddenField)gvRow.FindControl("hfAssetWoLineNo");
        HiddenField hfAssetAutoId = (HiddenField)gvRow.FindControl("hfAssetAutoId");
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvRow.FindControl("hfAssetServiceTypeAutoId");
        HiddenField hfFromTime42 = (HiddenField)gvRow.FindControl("hfFromTime62");
        HiddenField hfToTime43 = (HiddenField)gvRow.FindControl("hfToTime63");
        HiddenField hfAssetId6 = (HiddenField)gvRow.FindControl("hfAssetId6");

        var objAS = new BL.AssetScheduling();
        if (txt40.Text != string.Empty && txt42.Text != string.Empty && txt43.Text != string.Empty)
        {
            if (txt41.Text == "")
            {
                hfAssetScheduleAutoId = "0";
            }
            else
            {
                hfAssetScheduleAutoId = hfAssetId6.Value;
            }

            if (DateTime.Parse(Convert.ToDateTime(txtServiceDate.Text).AddDays(2).ToString("dd-MMM-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
            {
                DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.ToString(), BaseLocationAutoID, ddlClient.SelectedItem.Value,
                    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
                    hfAssetServiceTypeAutoId.Value, "", Convert.ToDateTime(txtServiceDate.Text).AddDays(2).ToString("dd-MMM-yyyy"), hfFromTime42.Value, hfToTime43.Value, txt40.Text,
                    txt42.Text, txt43.Text, BaseUserID);
                FillgvAssetScheduling();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
                lblErrorMsg.Text = "You cann't schedule for this Date as Date must be greater than or equal to current date !!";
                txt40.Text = "";

            }
        }
        else
        {
            lblErrorMsg.Text = "Employee No. , From Time & To Time cann't be blank !!";

        }
    }
    protected void txt70_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        TextBox txt41 = (TextBox)gvRow.FindControl("txt71");
        TextBox txt40 = (TextBox)gvRow.FindControl("txt70");
        TextBox txt42 = (TextBox)gvRow.FindControl("txt72");
        TextBox txt43 = (TextBox)gvRow.FindControl("txt73");
        var hfAssetScheduleAutoId = "";
        HiddenField hfAssetWoNo = (HiddenField)gvRow.FindControl("hfAssetWoNo");
        HiddenField hfAssetWoLineNo = (HiddenField)gvRow.FindControl("hfAssetWoLineNo");
        HiddenField hfAssetAutoId = (HiddenField)gvRow.FindControl("hfAssetAutoId");
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvRow.FindControl("hfAssetServiceTypeAutoId");
        HiddenField hfFromTime42 = (HiddenField)gvRow.FindControl("hfFromTime72");
        HiddenField hfToTime43 = (HiddenField)gvRow.FindControl("hfToTime73");
        HiddenField hfAssetId7 = (HiddenField)gvRow.FindControl("hfAssetId7");

        var objAS = new BL.AssetScheduling();
        if (txt40.Text != string.Empty && txt42.Text != string.Empty && txt43.Text != string.Empty)
        {
            if (txt41.Text == "")
            {
                hfAssetScheduleAutoId = "0";
            }
            else
            {
                hfAssetScheduleAutoId = hfAssetId7.Value;
            }

            if (DateTime.Parse(Convert.ToDateTime(txtServiceDate.Text).AddDays(3).ToString("dd-MMM-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
            {
                DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.ToString(), BaseLocationAutoID, ddlClient.SelectedItem.Value,
                    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
                    hfAssetServiceTypeAutoId.Value, "", Convert.ToDateTime(txtServiceDate.Text).AddDays(3).ToString("dd-MMM-yyyy"), hfFromTime42.Value, hfToTime43.Value, txt40.Text,
                    txt42.Text, txt43.Text, BaseUserID);
                FillgvAssetScheduling();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
                lblErrorMsg.Text = "You cann't schedule for this Date as Date must be greater than or equal to current date !!";
                txt40.Text = "";

            }
        }
        else
        {
            lblErrorMsg.Text = "Employee No. , From Time & To Time cann't be blank !!";

        }

    }
    protected void txt80_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        TextBox txt41 = (TextBox)gvRow.FindControl("txt81");
        TextBox txt40 = (TextBox)gvRow.FindControl("txt80");
        TextBox txt42 = (TextBox)gvRow.FindControl("txt82");
        TextBox txt43 = (TextBox)gvRow.FindControl("txt83");
        var hfAssetScheduleAutoId = "";
        HiddenField hfAssetWoNo = (HiddenField)gvRow.FindControl("hfAssetWoNo");
        HiddenField hfAssetWoLineNo = (HiddenField)gvRow.FindControl("hfAssetWoLineNo");
        HiddenField hfAssetAutoId = (HiddenField)gvRow.FindControl("hfAssetAutoId");
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvRow.FindControl("hfAssetServiceTypeAutoId");
        HiddenField hfFromTime42 = (HiddenField)gvRow.FindControl("hfFromTime82");
        HiddenField hfToTime43 = (HiddenField)gvRow.FindControl("hfToTime83");
        HiddenField hfAssetId8 = (HiddenField)gvRow.FindControl("hfAssetId8");

        var objAS = new BL.AssetScheduling();
        if (txt40.Text != string.Empty && txt42.Text != string.Empty && txt43.Text != string.Empty)
        {
            if (txt41.Text == "")
            {
                hfAssetScheduleAutoId = "0";
            }
            else
            {
                hfAssetScheduleAutoId = hfAssetId8.Value;
            }

            if (DateTime.Parse(Convert.ToDateTime(txtServiceDate.Text).AddDays(4).ToString("dd-MMM-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
            {
                DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.ToString(), BaseLocationAutoID, ddlClient.SelectedItem.Value,
                    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
                    hfAssetServiceTypeAutoId.Value, "", Convert.ToDateTime(txtServiceDate.Text).AddDays(4).ToString("dd-MMM-yyyy"), hfFromTime42.Value, hfToTime43.Value, txt40.Text,
                    txt42.Text, txt43.Text, BaseUserID);
                FillgvAssetScheduling();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
                lblErrorMsg.Text = "You cann't schedule for this Date as Date must be greater than or equal to current date !!";
                txt40.Text = "";

            }
        }
        else
        {
            lblErrorMsg.Text = "Employee No. , From Time & To Time cann't be blank !!";

        }
    }
    protected void txt90_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        TextBox txt41 = (TextBox)gvRow.FindControl("txt91");
        TextBox txt40 = (TextBox)gvRow.FindControl("txt90");
        TextBox txt42 = (TextBox)gvRow.FindControl("txt92");
        TextBox txt43 = (TextBox)gvRow.FindControl("txt93");
        var hfAssetScheduleAutoId = "";
        HiddenField hfAssetWoNo = (HiddenField)gvRow.FindControl("hfAssetWoNo");
        HiddenField hfAssetWoLineNo = (HiddenField)gvRow.FindControl("hfAssetWoLineNo");
        HiddenField hfAssetAutoId = (HiddenField)gvRow.FindControl("hfAssetAutoId");
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvRow.FindControl("hfAssetServiceTypeAutoId");
        HiddenField hfFromTime42 = (HiddenField)gvRow.FindControl("hfFromTime92");
        HiddenField hfToTime43 = (HiddenField)gvRow.FindControl("hfToTime93");
        HiddenField hfAssetId9 = (HiddenField)gvRow.FindControl("hfAssetId9");

        var objAS = new BL.AssetScheduling();
        if (txt40.Text != string.Empty && txt42.Text != string.Empty && txt43.Text != string.Empty)
        {
            if (txt41.Text == "")
            {
                hfAssetScheduleAutoId = "0";
            }
            else
            {
                hfAssetScheduleAutoId = hfAssetId9.Value;
            }

            if (DateTime.Parse(Convert.ToDateTime(txtServiceDate.Text).AddDays(5).ToString("dd-MMM-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
            {
                DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.ToString(), BaseLocationAutoID, ddlClient.SelectedItem.Value,
                    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
                    hfAssetServiceTypeAutoId.Value, "", Convert.ToDateTime(txtServiceDate.Text).AddDays(5).ToString("dd-MMM-yyyy"), hfFromTime42.Value, hfToTime43.Value, txt40.Text,
                    txt42.Text, txt43.Text, BaseUserID);
                FillgvAssetScheduling();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
                lblErrorMsg.Text = "You cann't schedule for this Date as Date must be greater than or equal to current date !!";
                txt40.Text = "";

            }
        }
        else
        {
            lblErrorMsg.Text = "Employee No. , From Time & To Time cann't be blank !!";

        }
    }
    protected void txt100_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        TextBox txt41 = (TextBox)gvRow.FindControl("txt101");
        TextBox txt40 = (TextBox)gvRow.FindControl("txt100");
        TextBox txt42 = (TextBox)gvRow.FindControl("txt102");
        TextBox txt43 = (TextBox)gvRow.FindControl("txt103");
        var hfAssetScheduleAutoId = "";
        HiddenField hfAssetWoNo = (HiddenField)gvRow.FindControl("hfAssetWoNo");
        HiddenField hfAssetWoLineNo = (HiddenField)gvRow.FindControl("hfAssetWoLineNo");
        HiddenField hfAssetAutoId = (HiddenField)gvRow.FindControl("hfAssetAutoId");
        HiddenField hfAssetServiceTypeAutoId = (HiddenField)gvRow.FindControl("hfAssetServiceTypeAutoId");
        HiddenField hfFromTime42 = (HiddenField)gvRow.FindControl("hfFromTime102");
        HiddenField hfToTime43 = (HiddenField)gvRow.FindControl("hfToTime103");
        HiddenField hfAssetId10 = (HiddenField)gvRow.FindControl("hfAssetId10");

        var objAS = new BL.AssetScheduling();
        if (txt40.Text != string.Empty && txt42.Text != string.Empty && txt43.Text != string.Empty)
        {
            if (txt41.Text == "")
            {
                hfAssetScheduleAutoId = "0";
            }
            else
            {
                hfAssetScheduleAutoId = hfAssetId10.Value;
            }

            if (DateTime.Parse(Convert.ToDateTime(txtServiceDate.Text).AddDays(6).ToString("dd-MMM-yyyy")) >= DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy")))
            {
                DataSet ds = objAS.AssetScheduleSaveUpdate(hfAssetScheduleAutoId.ToString(), BaseLocationAutoID, ddlClient.SelectedItem.Value,
                    ddlAsmt.SelectedItem.Value, hfAssetWoNo.Value, hfAssetWoLineNo.Value, ddlPost.SelectedItem.Value, hfAssetAutoId.Value,
                    hfAssetServiceTypeAutoId.Value, "", Convert.ToDateTime(txtServiceDate.Text).AddDays(6).ToString("dd-MMM-yyyy"), hfFromTime42.Value, hfToTime43.Value, txt40.Text,
                    txt42.Text, txt43.Text, BaseUserID);
                FillgvAssetScheduling();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            else
            {
                lblErrorMsg.Text = "You cann't schedule for this Date as Date must be greater than or equal to current date !!";
                txt40.Text = "";

            }
        }
        else
        {
            lblErrorMsg.Text = "Employee No. , From Time & To Time cann't be blank !!";

        }
    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlWeek();
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlWeek();
    }
    protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAutoFillSchedule_Click(object sender, EventArgs e)
    {
        var objAS = new BL.AssetScheduling();
        DataSet ds = objAS.AssetScheduleAutoFill(BaseLocationAutoID, ddlClient.SelectedItem.Value, ddlAsmt.SelectedItem.Value, ddlPost.SelectedItem.Value, txtServiceDate.Text, txtToDate.Text);
        FillgvAssetScheduling();
        btnAutoFillSchedule.Visible = false;

    }
}