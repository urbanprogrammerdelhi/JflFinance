using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transactions_PlumbingEmployeeDashboard : BasePage
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
                var VirtualDirNameLenght = 0;
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
        if(!IsPostBack)
        {
            if (IsReadAccess)
            {
                FillgvEmployeeDashboard();
            }
            else
            {
                Response.Redirect("../UserManagement/Home.aspx");
            }
        }
    }

    protected void FillgvEmployeeDashboard()
    {
        DataSet ds = new DataSet();
        BL.Sales objSales = new BL.Sales();
        ds = objSales.PlumbingEmployeeDashboard(DateTime.Today.ToString("dd-MMM-yyyy"));
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {

            BoundField bfield = new BoundField();
            bfield.HeaderText = "Employee Number";
            bfield.DataField = "EmployeeNumber";
            gvEmployeeDashboard.Columns.Add(bfield);

            bfield = new BoundField();
            bfield.HeaderText = "Employee Name";
            bfield.DataField = "EmployeeName";
            gvEmployeeDashboard.Columns.Add(bfield);

            TemplateField tfield = new TemplateField();
            tfield.HeaderText = ds.Tables[0].Columns[2].ColumnName;
            gvEmployeeDashboard.Columns.Add(tfield);

            tfield = new TemplateField();
            tfield.HeaderText = ds.Tables[0].Columns[3].ColumnName;
            gvEmployeeDashboard.Columns.Add(tfield);

            tfield = new TemplateField();
            tfield.HeaderText = ds.Tables[0].Columns[4].ColumnName;
            gvEmployeeDashboard.Columns.Add(tfield);

            tfield = new TemplateField();
            tfield.HeaderText = ds.Tables[0].Columns[5].ColumnName;
            gvEmployeeDashboard.Columns.Add(tfield);

            gvEmployeeDashboard.Visible = true;
            gvEmployeeDashboard.DataSource = ds;
            gvEmployeeDashboard.DataBind();
        }
        else
        {
            lblError.Text = Resources.Resource.NoRecordFound;
            gvEmployeeDashboard.Visible = false;
        }
    }
    protected void gvEmployeeDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //LinkButton lbTimeSlot1 = new LinkButton();
            //lbTimeSlot1.ID = "lbTimeSlot1";
            //lbTimeSlot1.Text = (e.Row.DataItem as DataRowView).Row[2].ToString();
            //e.Row.Cells[2].Controls.Add(lbTimeSlot1);

            //LinkButton lbTimeSlot2 = new LinkButton();
            //lbTimeSlot2.ID = "lbTimeSlot2";
            //lbTimeSlot2.Text = (e.Row.DataItem as DataRowView).Row[3].ToString();
            //e.Row.Cells[3].Controls.Add(lbTimeSlot2);

            //LinkButton lbTimeSlot3 = new LinkButton();
            //lbTimeSlot3.ID = "lbTimeSlot3";
            //lbTimeSlot3.Text = (e.Row.DataItem as DataRowView).Row[4].ToString();
            //e.Row.Cells[4].Controls.Add(lbTimeSlot3);

            //LinkButton lbTimeSlot4 = new LinkButton();
            //lbTimeSlot4.ID = "lbTimeSlot4";
            //lbTimeSlot4.Text = (e.Row.DataItem as DataRowView).Row[5].ToString();
            //e.Row.Cells[5].Controls.Add(lbTimeSlot4);

            //HttpUtility.HtmlDecode();

            //e.Row.Cells[2].Text = HttpUtility.HtmlDecode((e.Row.DataItem as DataRowView).Row[2].ToString());
            //e.Row.Cells[3].Text = HttpUtility.HtmlDecode((e.Row.DataItem as DataRowView).Row[3].ToString());
            //e.Row.Cells[4].Text = HttpUtility.HtmlDecode((e.Row.DataItem as DataRowView).Row[4].ToString());
            //e.Row.Cells[5].Text = HttpUtility.HtmlDecode((e.Row.DataItem as DataRowView).Row[5].ToString());

            for (int i = 2; i <= 5; i++)
            {
                string strWoDetails = string.Empty;
                if ((e.Row.DataItem as DataRowView).Row[i].ToString() != string.Empty)
                {
                    strWoDetails = "<div class='outer'>" + "Scheduled" + "<div class='box1'>" +
                        (e.Row.DataItem as DataRowView).Row[i].ToString() + "</div></div>";
                }
                else
                {
                    strWoDetails = "<div class='single'>" + (e.Row.DataItem as DataRowView).Row[i].ToString() + "</div>";
                }
                e.Row.Cells[i].Text = strWoDetails;
            }
        }
    }
}