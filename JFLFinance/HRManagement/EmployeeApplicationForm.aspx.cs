using System;
using System.Collections;

public partial class HRManagement_EmployeeApplicationForm : BasePage
{
    string employeeNumber = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["EmployeeNumber"] != null)
            {
                employeeNumber = Request.QueryString["EmployeeNumber"].ToString();

                var strReportPagePath = "../Reports/HR/";

                var hshRptParameters = new Hashtable();
                hshRptParameters = ReportParameter_Get();
                Context.Items.Remove("cxtReportFileName");
                Context.Items.Add("cxtReportFileName", "EmployeeApplicationForm.rpt");
                Context.Items.Add("cxtHashParameters", hshRptParameters);
                Context.Items.Add("cxtReportID", "ReportID");
                Context.Items.Add("cxtReportPagePath", strReportPagePath);
                Context.Items["cxtReturnPage"] = "../HRManagement/EmployeeMaster.aspx?strStatus=Update&strEmployeeNumber=" + employeeNumber;

                Server.Transfer("../Reports/ViewReport1.aspx");
            }
        }
    }

    private Hashtable ReportParameter_Get()
    {
        string img_url = @"\\Images\EmployeeImages\NoImageAvailable.jpg";
        img_url = @"\\Images\EmployeeImages\" + employeeNumber + ".jpg";
        img_url = Server.MapPath(img_url);

        var hshRptParameters = new Hashtable();
        hshRptParameters.Add(DL.Properties.Resources.EmployeeNumber, employeeNumber);
        hshRptParameters.Add(DL.Properties.Resources.CompanyCode, BaseCompanyCode);
        hshRptParameters.Add(@"@ImageURL", img_url);
        return hshRptParameters;
    }
}