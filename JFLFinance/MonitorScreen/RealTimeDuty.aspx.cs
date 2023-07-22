using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MonitorScreen_RealTimeDuty : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillddlAreaID();
            txtFromDate.Attributes.Add("readonly", "readonly");
            txtToDate.Attributes.Add("readonly", "readonly");
            txtFromDate.Text = DateFormat(DateTime.Today.ToString());
            txtToDate.Text = DateFormat(DateTime.Today.ToString());
        }
    }
    protected void FillddlAreaID()
    {
        ListItem li = new ListItem();

        BL.OperationManagement objSale = new BL.OperationManagement();
        DataSet dsClient = new DataSet();
        dsClient = objSale.AreaIdGet((BaseLocationAutoID), BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));

        if (dsClient != null && dsClient.Tables.Count > 0 && dsClient.Tables[0].Rows.Count > 0)
        {
            ddlAreaID.DataSource = dsClient.Tables[0];
            ddlAreaID.DataValueField = "AreaID";
            ddlAreaID.DataTextField = "AreaDesc";
            ddlAreaID.DataBind();
            li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlAreaID.Items.Insert(0, li);
        }
        if (ddlAreaID.Text == "")
        {
            li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlAreaID.Items.Add(li);
        }
        FillddlClient();
    }
    protected void ddlAreaID_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlClient();
    }
    protected void FillddlClient()
    {
        BL.Sales objSale = new BL.Sales();
        DataSet ds = new DataSet();
        if (BaseIsAdmin.Trim().ToLower() == "C".Trim().ToLower())
        {
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, BaseUserID);
        }
        else
        {
            ds = objSale.ClientsMappedToLocationGet(BaseLocationAutoID, ddlAreaID.SelectedItem.Value.ToString(), string.Empty, BaseUserEmployeeNumber.ToString(), BaseUserIsAreaIncharge.ToString(), DateFormat(DateTime.Now), DateFormat(DateTime.Now));
        }
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ddlClient.DataSource = ds.Tables[0];
            ddlClient.DataTextField = "ClientCodeName";
            ddlClient.DataValueField = "ClientCode";
            ddlClient.DataBind();

            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlClient.Items.Insert(0, li);
        }
        else
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.NoDataToShow;
            li.Value = "";
            ddlClient.Items.Add(li);
        }
        FillddlAsmt();
    }
    protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillddlAsmt();
    }
    protected void FillddlAsmt()
    {
        if (ddlClient.SelectedItem.Value == "ALL")
        {
            ListItem li = new ListItem();
            li.Text = Resources.Resource.All;
            li.Value = "ALL";
            ddlAsmt.Items.Insert(0, li);
        }
        else
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
                    ddlAsmt.DataTextField = "AsmtId";
                    ddlAsmt.DataValueField = "AsmtId";
                    ddlAsmt.DataBind();

                    ListItem li = new ListItem();
                    li.Text = Resources.Resource.All;
                    li.Value = "ALL";
                    ddlAsmt.Items.Insert(0, li);
                }
                else
                {
                    var li = new ListItem
                    {
                        Text = @Resources.Resource.NoDataToShow,
                        Value = string.Empty
                    };
                    ddlAsmt.Items.Add(li);
                }
            }
            else
            {
                var li = new ListItem { Text = @Resources.Resource.NoDataToShow, Value = string.Empty };
                ddlAsmt.Items.Add(li);
            }
        }
    }
    protected void FillgvRealTimeAtt()
    {
        BL.NFC objNFC = new BL.NFC();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int dtflag;
        dtflag = 1;
        ds = objNFC.BlDeviceAttendanceGet(BaseLocationAutoID, ddlClient.SelectedItem.Value.ToString(), ddlAsmt.SelectedItem.Value.ToString(), DateFormat(txtFromDate.Text), DateFormat(txtToDate.Text));
        dt = ds.Tables[0];

        //to fix empety gridview
        if (dt.Rows.Count == 0)
        {
            dtflag = 0;
            dt.Rows.Add(dt.NewRow());
        }
        gvRealTimeAtt.DataSource = dt;
        gvRealTimeAtt.DataBind();

        if (dtflag == 0)//to fix empety gridview
        {
            gvRealTimeAtt.Rows[0].Visible = false;
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtFromDate.Text) > DateTime.Parse(txtToDate.Text))
        {
            txtToDate.Text = txtFromDate.Text;
        }
        FillgvRealTimeAtt();
    }
}