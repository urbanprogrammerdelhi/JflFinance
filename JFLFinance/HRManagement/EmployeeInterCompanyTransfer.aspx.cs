using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class HRManagement_EmployeeInterCompanyTransfer : BasePage//System.Web.UI.Page
{

    #region Properties

    /// <summary>
    /// Returns User Read Rights.
    /// </summary>
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

    #region PageLoad

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Text.StringBuilder javaScript = new System.Text.StringBuilder();
            javaScript.Append("<script type='text/javascript'>");
            javaScript.Append("window.document.body.onload = function ()");
            javaScript.Append("{\n");
            javaScript.Append("PageTitle('" + Resources.Resource.EmployeeInterCompanyTransfer + "');");
            javaScript.Append("};\n");
            javaScript.Append("// -->\n");
            javaScript.Append("</script>");
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BodyLoadUnloadScript", javaScript.ToString());


            if (IsReadAccess == true)
            {
                FillddlAreaID();
                FillgvEmpInterCompanyTransfer(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString());
                FillddlSearchBy();
                txtSearch.Visible = true;
                txtAsOnDate.Visible = false;
                HLAsOnDate.Visible = false;

            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }
    #endregion

    #region Function related to Fill Gridview
    private void FillgvEmpInterCompanyTransfer(string strlocationAutoID, string strAreaID)
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataSet ds = new DataSet();
        DataTable dtEmpInterCompanyTransfer = new DataTable();
      
        var selectedDate = string.Empty;
        if (ddlEmployeeGetType.SelectedValue == "A")
        {
            selectedDate = txtAsOnDate.Text.ToString();
        }
        else
        {
            selectedDate = "01/01/1900";
        }

        ds = objHRManagement.AreaInchargeGetAll(strlocationAutoID, strAreaID.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), selectedDate, selectedDate);

        dtEmpInterCompanyTransfer = ds.Tables[0];
        if (ds != null && ds.Tables.Count > 0 && dtEmpInterCompanyTransfer.Rows.Count > 0)
        {
            gvEmpInterCompanyTransfer.DataSource = dtEmpInterCompanyTransfer;
            gvEmpInterCompanyTransfer.DataBind();
        }
        else
        {
            dtEmpInterCompanyTransfer.Rows.Add(dtEmpInterCompanyTransfer.NewRow());
            gvEmpInterCompanyTransfer.DataSource = dtEmpInterCompanyTransfer;
            gvEmpInterCompanyTransfer.DataBind();
            int TotalColumns = gvEmpInterCompanyTransfer.Rows[0].Cells.Count;
            gvEmpInterCompanyTransfer.Rows[0].Cells.Clear();
            gvEmpInterCompanyTransfer.Rows[0].Cells.Add(new TableCell());
            gvEmpInterCompanyTransfer.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvEmpInterCompanyTransfer.Rows[0].Cells[0].Text = Resources.Resource.NoRecordFound;
        }
    }
    #endregion

    #region Function Related to GridViewevents

    protected void gvEmpInterCompanyTransfer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow objGridViewRow = e.Row;
        Label lblSerialNo = (Label)objGridViewRow.FindControl("lblSerialNo");
        if (lblSerialNo != null)
        {
            int serialNo = gvEmpInterCompanyTransfer.PageIndex * gvEmpInterCompanyTransfer.PageSize + int.Parse(objGridViewRow.RowIndex.ToString());
            lblSerialNo.Text = Convert.ToString((serialNo + 1));
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (IsModifyAccess == false)
            {
                ImageButton IBEditTran = (ImageButton)e.Row.FindControl("IBEditTran");
                ImageButton IBCorrect = (ImageButton)e.Row.FindControl("IBCorrect");
                if (IBEditTran != null)
                {
                    IBEditTran.Visible = false;

                }
                if (IBCorrect != null)
                {
                    IBCorrect.Visible = false;

                }
            }
            e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
            e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
        }
    }
    #endregion

    protected void IBCorrect_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton objLinkButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        Label lblLocationAutoID = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationAutoID");
        Label lblEmployeeName = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmployeeName");
        Label lblEmployeeNumber = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        Label lblCompanyCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompanyCode");
        Label lblHrLocationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblHrLocationCode");
        Label lblLocationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationCode");
        Label lblDesignationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesignationCode");
        Label lblCategoryCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCategoryCode");
        Label lblJobClassCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblJobClassCode");
        Label lblJobTypeCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblJobTypeCode");
        Label lblDesiEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesiEffectiveFrom");
        Label lbllocationEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lbllocationEffectiveFrom");
        Label lblCatEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCatEffectiveFrom");
        Label lblCompEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompEffectiveFrom");
        Label lblEmpJobTypeEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmpJobTypeEffectiveFrom");
        Label lblEmpJobClassEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmpJobClassEffectiveFrom");

        Label lblDepDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepDesc");
        Label lblDepCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepCode");
        Label lblDepEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepEffectiveFrom");

        Label lblAreaID = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaID");
        Label lblAreaDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaDesc");
        Label lblAreaEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaEffectiveFrom");
        Label lblGradeDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblGradeDesc");
        Label lblGradeCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblGradeCode");
        Label lblCompanyDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompanyDesc");
        Label lblHrLocationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblHrLocationDesc");
        Label lblLocationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationDesc");
        Label lblDesignationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesignationDesc");
        Label lblCategoryDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCategoryDesc");
        Response.Redirect("EmployeeInterCompanyTransferCorrection.aspx?LocationAutoID=" + lblLocationAutoID.Text + "&EmployeeName=" + lblEmployeeName.Text + "&EmployeeNumber=" + lblEmployeeNumber.Text + "&CompanyCode=" + lblCompanyCode.Text + "&HrLocationCode=" + lblHrLocationCode.Text + "&LocationCode=" + lblLocationCode.Text + "&DesignationCode=" + lblDesignationCode.Text + "&CategoryCode=" + lblCategoryCode.Text + "&DepartmentCode=" + lblDepCode.Text + "&DeptEffectiveFrom=" + lblDepEffectiveFrom.Text + "&DepartmentDesc=" + lblDepDesc.Text + "&AreaID=" + lblAreaID.Text + "&AreaDesc=" + lblAreaDesc.Text + "&AreaEffectiveFrom=" + lblAreaEffectiveFrom.Text + "&JobClassCode=" + lblJobClassCode.Text + "&JobTypeCode=" + lblJobTypeCode.Text + "&DesiEffectiveFrom=" + lblDesiEffectiveFrom.Text + "&locationEffectiveFrom=" + lbllocationEffectiveFrom.Text + "&CatEffectiveFrom=" + lblCatEffectiveFrom.Text + "&EmpJobTypeEffectiveFrom=" + lblEmpJobTypeEffectiveFrom.Text + "&EmpJobClassEffectiveFrom=" + lblEmpJobClassEffectiveFrom.Text + "&CompanyDesc=" + lblCompanyDesc.Text + "&HrLocationDesc=" + lblHrLocationDesc.Text + "&LocationDesc=" + lblLocationDesc.Text + "&DesignationDesc=" + lblDesignationDesc.Text + "&CategoryDesc=" + lblCategoryDesc.Text + "&CompEffectiveFrom=" + lblCompEffectiveFrom.Text + "&OperationType=" + "Correction" + "&GradeCode=" + lblGradeCode.Text + "&GradeDesc=" + lblGradeDesc.Text);
    }

    protected void IBRollBack_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton objLinkButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        Label lblLocationAutoID = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationAutoID");
        Label lblEmployeeName = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmployeeName");
        Label lblEmployeeNumber = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        Label lblCompanyCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompanyCode");
        Label lblHrLocationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblHrLocationCode");
        Label lblLocationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationCode");
        Label lblDesignationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesignationCode");
        Label lblCategoryCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCategoryCode");
        Label lblJobClassCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblJobClassCode");
        Label lblJobTypeCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblJobTypeCode");
        Label lblDesiEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesiEffectiveFrom");
        Label lbllocationEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lbllocationEffectiveFrom");
        Label lblCatEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCatEffectiveFrom");
        Label lblCompEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompEffectiveFrom");
        Label lblEmpJobTypeEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmpJobTypeEffectiveFrom");
        Label lblEmpJobClassEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmpJobClassEffectiveFrom");

        Label lblDepDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepDesc");
        Label lblDepCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepCode");
        Label lblDepEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepEffectiveFrom");
        Label lblGradeDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblGradeDesc");
        Label lblGradeCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblGradeCode");

        Label lblAreaID = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaID");
        Label lblAreaDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaDesc");
        Label lblAreaEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaEffectiveFrom");
        Label lblCompanyDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompanyDesc");
        Label lblHrLocationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblHrLocationDesc");
        Label lblLocationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationDesc");
        Label lblDesignationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesignationDesc");
        Label lblCategoryDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCategoryDesc");
        Response.Redirect("EmployeeInterCompanyTransferCorrection.aspx?LocationAutoID=" + lblLocationAutoID.Text + "&EmployeeName=" + lblEmployeeName.Text + "&EmployeeNumber=" + lblEmployeeNumber.Text + "&CompanyCode=" + lblCompanyCode.Text + "&HrLocationCode=" + lblHrLocationCode.Text + "&LocationCode=" + lblLocationCode.Text + "&DesignationCode=" + lblDesignationCode.Text + "&CategoryCode=" + lblCategoryCode.Text + "&JobClassCode=" + lblJobClassCode.Text + "&AreaID=" + lblAreaID.Text + "&AreaDesc=" + lblAreaDesc.Text + "&AreaEffectiveFrom=" + lblAreaEffectiveFrom.Text + "&DepartmentCode=" + lblDepCode.Text + "&DeptEffectiveFrom=" + lblDepEffectiveFrom.Text + "&DepartmentDesc=" + lblDepDesc.Text + "&JobTypeCode=" + lblJobTypeCode.Text + "&DesiEffectiveFrom=" + lblDesiEffectiveFrom.Text + "&locationEffectiveFrom=" + lbllocationEffectiveFrom.Text + "&CatEffectiveFrom=" + lblCatEffectiveFrom.Text + "&EmpJobTypeEffectiveFrom=" + lblEmpJobTypeEffectiveFrom.Text + "&EmpJobClassEffectiveFrom=" + lblEmpJobClassEffectiveFrom.Text + "&CompanyDesc=" + lblCompanyDesc.Text + "&HrLocationDesc=" + lblHrLocationDesc.Text + "&LocationDesc=" + lblLocationDesc.Text + "&DesignationDesc=" + lblDesignationDesc.Text + "&CategoryDesc=" + lblCategoryDesc.Text + "&CompEffectiveFrom=" + lblCompEffectiveFrom.Text + "&OperationType=" + "RollBack" + "&GradeCode=" + lblGradeCode.Text + "&GradeDesc=" + lblGradeDesc.Text);

    }
    protected void IBEditTran_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton objLinkButton = (ImageButton)sender;
        GridViewRow row = (GridViewRow)objLinkButton.NamingContainer;
        Label lblLocationAutoID = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationAutoID");
        Label lblEmployeeName = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmployeeName");
        Label lblEmployeeNumber = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmployeeNumber");
        Label lblCompanyCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompanyCode");
        Label lblHrLocationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblHrLocationCode");
        Label lblLocationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationCode");
        Label lblDesignationCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesignationCode");
        Label lblCategoryCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCategoryCode");
        Label lblJobClassCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblJobClassCode");
        Label lblJobTypeCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblJobTypeCode");
        Label lblDesiEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesiEffectiveFrom");
        Label lbllocationEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lbllocationEffectiveFrom");
        Label lblCatEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCatEffectiveFrom");
        Label lblCompEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompEffectiveFrom");
        Label lblEmpJobTypeEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmpJobTypeEffectiveFrom");
        Label lblEmpJobClassEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblEmpJobClassEffectiveFrom");
        Label lblAreaID = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaID");
        Label lblAreaDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaDesc");
        Label lblAreaEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblAreaEffectiveFrom");

        Label lblDepDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepDesc");
        Label lblDepCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepCode");
        Label lblDepEffectiveFrom = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDepEffectiveFrom");
        Label lblGradeDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblGradeDesc");
        Label lblGradeCode = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblGradeCode");

        Label lblCompanyDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCompanyDesc");
        Label lblHrLocationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblHrLocationDesc");
        Label lblLocationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblLocationDesc");
        Label lblDesignationDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblDesignationDesc");
        Label lblCategoryDesc = (Label)gvEmpInterCompanyTransfer.Rows[row.RowIndex].FindControl("lblCategoryDesc");
        Response.Redirect("EmployeeInterCompanyTransferCorrection.aspx?LocationAutoID=" + lblLocationAutoID.Text + "&EmployeeName=" + lblEmployeeName.Text + "&EmployeeNumber=" + lblEmployeeNumber.Text + "&CompanyCode=" + lblCompanyCode.Text + "&HrLocationCode=" + lblHrLocationCode.Text + "&LocationCode=" + lblLocationCode.Text + "&DesignationCode=" + lblDesignationCode.Text + "&CategoryCode=" + lblCategoryCode.Text + "&AreaID=" + lblAreaID.Text + "&AreaDesc=" + lblAreaDesc.Text + "&AreaEffectiveFrom=" + lblAreaEffectiveFrom.Text + "&DepartmentCode=" + lblDepCode.Text + "&DeptEffectiveFrom=" + lblDepEffectiveFrom.Text + "&DepartmentDesc=" + lblDepDesc.Text + "&JobClassCode=" + lblJobClassCode.Text + "&JobTypeCode=" + lblJobTypeCode.Text + "&DesiEffectiveFrom=" + lblDesiEffectiveFrom.Text + "&locationEffectiveFrom=" + lbllocationEffectiveFrom.Text + "&CatEffectiveFrom=" + lblCatEffectiveFrom.Text + "&EmpJobTypeEffectiveFrom=" + lblEmpJobTypeEffectiveFrom.Text + "&EmpJobClassEffectiveFrom=" + lblEmpJobClassEffectiveFrom.Text + "&CompanyDesc=" + lblCompanyDesc.Text + "&HrLocationDesc=" + lblHrLocationDesc.Text + "&LocationDesc=" + lblLocationDesc.Text + "&DesignationDesc=" + lblDesignationDesc.Text + "&CategoryDesc=" + lblCategoryDesc.Text + "&CompEffectiveFrom=" + lblCompEffectiveFrom.Text + "&OperationType=" + "Amend" + "&GradeCode="+ lblGradeCode.Text + "&GradeDesc="+lblGradeDesc.Text);

    }

    protected void gvEmpInterCompanyTransfer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmpInterCompanyTransfer.PageIndex = e.NewPageIndex;
        FillgvEmpInterCompanyTransfer(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString());
    }
    #region Function Related to Search In Gridview LOI received
    private void ChangeTextBoxBasedOnddlSearchBySelectedIndexChanged()
    {
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        if (txtSearch.Text != "")
        {
            btnViewAll.Visible = true;
        }

        hfSearchText.Value = txtSearch.Text.Trim();
        SearchAction();
    }
    /// <summary>
    /// Function To Search In grid view 
    /// </summary>
    private void SearchAction()
    {
        BL.HRManagement objHRManagement = new BL.HRManagement();
        DataTable dtAddEmpDetail = new DataTable();
        var selectedDate = string.Empty;
        if (ddlEmployeeGetType.SelectedValue == "A")
        {
            selectedDate = txtAsOnDate.Text.ToString();
        }
        else
        {
            selectedDate = "01/01/1900";
        }
        dtAddEmpDetail = objHRManagement.AreaInchargeGetAll(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString(), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), selectedDate, selectedDate).Tables[0];
        dtAddEmpDetail.Columns["EmployeeNumber"].ColumnName = Resources.Resource.EmployeeNumber;
        dtAddEmpDetail.Columns["EmployeeName"].ColumnName = Resources.Resource.EmployeeName;
        dtAddEmpDetail.Columns["HrLocationDesc"].ColumnName = Resources.Resource.HrLocation;
        dtAddEmpDetail.Columns["LocationDesc"].ColumnName = Resources.Resource.Location;
        dtAddEmpDetail.Columns["DesignationDesc"].ColumnName = Resources.Resource.Designation;
        dtAddEmpDetail.Columns["CategoryDesc"].ColumnName = Resources.Resource.Category;
        DataTable dt = new DataTable();
        DataView dv = new DataView(dtAddEmpDetail);

        dv.RowFilter = string.Format("[{0}] like '%{1}%'", ddlSearchBy.SelectedValue.ToString(), hfSearchText.Value);

        dt = dv.ToTable();
        dt.Columns[Resources.Resource.EmployeeNumber].ColumnName = "EmployeeNumber";
        dt.Columns[Resources.Resource.EmployeeName].ColumnName = "EmployeeName";
        dt.Columns[Resources.Resource.HrLocation].ColumnName = "HrLocationDesc";
        dt.Columns[Resources.Resource.Location].ColumnName = "LocationDesc";
        dt.Columns[Resources.Resource.Designation].ColumnName = "DesignationDesc";
        dt.Columns[Resources.Resource.Category].ColumnName = "CategoryDesc";
        gvEmpInterCompanyTransfer.DataSource = dt;
        gvEmpInterCompanyTransfer.DataBind();
    }

    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        FillgvEmpInterCompanyTransfer(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString());
    }

    private void FillddlSearchBy()
    {
        ArrayList arr = new ArrayList();
        arr.Add(gvEmpInterCompanyTransfer.Columns[1]);
        arr.Add(gvEmpInterCompanyTransfer.Columns[2]);
        arr.Add(gvEmpInterCompanyTransfer.Columns[4]);
        arr.Add(gvEmpInterCompanyTransfer.Columns[5]);
        arr.Add(gvEmpInterCompanyTransfer.Columns[6]);
        arr.Add(gvEmpInterCompanyTransfer.Columns[7]);
        ddlSearchBy.DataSource = arr;
        ddlSearchBy.DataTextField = "HeaderText";
        ddlSearchBy.DataValueField = "HeaderText";
        ddlSearchBy.DataBind();
    }

    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvEmpInterCompanyTransfer(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString());
    }

    protected void FillddlAreaID()
    {
        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsArea = new DataSet();
        dsArea = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateTime.Now.ToString(), DateTime.Now.ToString());
        ddlAreaID.DataTextField = "AreaDesc";
        ddlAreaID.DataValueField = "AreaID";
        ddlAreaID.DataSource = dsArea;
        ddlAreaID.DataBind();

        ListItem li = new ListItem();
        li.Text = Resources.Resource.All;
        li.Value = "ALL";

        ddlAreaID.Items.Insert(0, li);

    }
    #endregion

    protected void ddlEmployeeGetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmployeeGetType.SelectedValue == "A")
        {
            txtAsOnDate.Visible = true;
            HLAsOnDate.Visible = true;
            txtAsOnDate.Text = DateFormat(DateTime.Now.ToString());
        }
        else
        {
            txtAsOnDate.Visible = false;
            HLAsOnDate.Visible = false;
        }
    }

    protected void btnGetEmployeeBasedOnStatus_Click(object sender, EventArgs e)
    {
        FillgvEmpInterCompanyTransfer(BaseLocationAutoID, ddlAreaID.SelectedValue.ToString());
    }
}

