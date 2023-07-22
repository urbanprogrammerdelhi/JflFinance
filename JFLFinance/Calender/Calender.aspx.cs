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
using System.Globalization;
using System.Threading;

public partial class Calender : BasePage//System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (Session["MyCulture"].ToString().ToUpper() == "AR-SA")
        //{
        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
        //    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
        //}


        for (int i = 0; i < 12; i++)
            this.CboMonth.Items[i].Text = new DateTime(1, i + 1, 1).ToString(""); // Month Format
       
        if (!Page.IsPostBack)
        {

            //Adding the value to Combobox. [1900- thisYear]				
            for (int iYear = 1900; iYear <= 2100; iYear++)
            {
                CboYear.Items.Add(new ListItem(iYear.ToString()));
            }
            refreshControls();
            
        }
    }
    protected void CdrDatePicker_SelectionChanged(object sender, EventArgs e)
    {
        
        DateTime dt = new DateTime();
        dt = CdrDatePicker.SelectedDate;
        string retDate = dt.ToString("dd-MMM-yyyy");//, DateTimeFormatInfo.CurrentInfo);
        returnToPage(retDate);	
    }
    protected void CboYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        setCalendarDate();
    }
    protected void CboMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        setCalendarDate();
    }
    protected void hlSelectDate_Click(object sender, EventArgs e)
    {
        string ReturnDate = CdrDatePicker.SelectedDate.ToString("dd-MMM-yyyy");
        returnToPage(ReturnDate);
    }

    private void returnToPage(string retDate)
    {
        //"<script>window.opener." + Request.QueryString("field") + ".value ='" + ReturnDate + "';" + " " + "window.close();</script>")
        Response.Write("<script>window.opener." + Request.QueryString["field"].ToString() + ".value='" + retDate + "';window.close();</script>");
        //Response.Write("<script>alert(window.opener.document.WebForm1.txtDate.value);</script>");
    }
    private void setCalendarDate()
    {
        int day;
        int year = Int32.Parse(CboYear.SelectedValue.ToString());
        int month = Int32.Parse(CboMonth.SelectedValue.ToString());
        day = CdrDatePicker.SelectedDate.Day;
        if (day > DateTime.DaysInMonth(year, month))
        {
            day = DateTime.DaysInMonth(year, month);
        }
        CdrDatePicker.VisibleDate = new DateTime(year, month, day);
    }
    private void refreshControls()
    {
        DateTime SelectedDate;
        if (!(Request.QueryString["ShowDate"] == null))
        {
            SelectedDate = System.Convert.ToDateTime(Request.QueryString["ShowDate"]);
            CboYear.SelectedIndex = SelectedDate.Year - 1900;
            CboMonth.SelectedIndex = SelectedDate.Month - 1;
            CdrDatePicker.VisibleDate = SelectedDate.Date;
        }
        else
        {
            CboYear.SelectedIndex = DateTime.Now.Year - 1900;
            CboMonth.SelectedIndex = DateTime.Now.Month - 1;
            CdrDatePicker.VisibleDate = DateTime.Now.Date;
        }
    }
    protected void CdrDatePicker_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        CboYear.SelectedIndex = CdrDatePicker.VisibleDate.Year - 1900;
        CboMonth.SelectedIndex = CdrDatePicker.VisibleDate.Month - 1;
    }
}
