// ***********************************************************************
// Assembly         : 
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="SalesTermination.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Sales namespace.
/// </summary>
namespace Sales
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Web.UI.WebControls;
    using Telerik.Web.UI;

    /// <summary>
    /// Sale Order Termination
    /// </summary>
    public partial class Sales_SalesTermination : BasePage
    {

        /// <summary>
        /// variable index is used for paging
        /// </summary>
        private static int staticIndex;

        /// <summary>
        /// Sale Order Termination Screen Page Load Event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Event Args</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ChangedTerminationDetail"] = null;
                FillddlSortedBy();
                FillMenu();
            }
        }

        /// <summary>
        /// Bind the Drop down list box with sorting options
        /// </summary>
        protected void FillddlSortedBy()
        {
            ddlSortedBy.Items.Clear();

            var li = new RadComboBoxItem {Text = Resources.Resource.Code, Value = @"CodeName"};
            ddlSortedBy.Items.Add(li);

            li = new RadComboBoxItem {Text = Resources.Resource.Name, Value = @"NameCode"};
            ddlSortedBy.Items.Add(li);


            ViewState["ChangedTerminationDetail"] = null;
            ddlSelectedItems.Items.Clear();
            gvSaleTermination.DataSource = null;
            gvSaleTermination.DataBind();
            FillMenu();
        }

        /// <summary>
        /// Fill Termination navigation Menu Based on Selected Termination Type (Client/Assignment/SoNo)
        /// </summary>
        protected void FillMenu()
        {
            var objSales = new BL.Sales();
            using (
                DataSet ds = objSales.GetDataBasedOnTerminationType(BaseLocationAutoID, "ALL", string.Empty,
                    BaseUserEmployeeNumber, BaseUserIsAreaIncharge,
                    DateTime.Now.ToString(Resources.Resource.ScheduleDefaultDateFormat),
                    DateTime.Now.ToString(Resources.Resource.ScheduleDefaultDateFormat),
                    ddlTerminationType.SelectedValue, ddlSortedBy.SelectedValue))
            {
                tvMenu.Nodes.Clear();
                GenerateTreeView(ds);
            }
        }

        /// <summary>
        /// generate the data set with three tables and their relations now build the node hierarchy, starting at the top
        /// </summary>
        /// <param name="dsMenus">dataset Menu items</param>
        protected void GenerateTreeView(DataSet dsMenus)
        {
            // generate the data set with three tables and their relations
            // now build the node hierarchy, starting at the top
            var mainItem = new RadTreeNode(ddlTerminationType.SelectedItem.Text)
            {
                ImageUrl = @"~/Images/OfficeCustomer.png",
                CssClass = "customPointer"
            };

            tvMenu.Nodes.Add(mainItem);

            foreach (DataRow parentItem in dsMenus.Tables[0].Rows)
            {
                if (parentItem["TerminationType"].ToString() != string.Empty)
                {
                    var subParentItem = new RadTreeNode(parentItem["Name"].ToString())
                    {
                        Value = parentItem["Code"].ToString(),
                        CssClass = "customPointer"
                    };

                    if (int.Parse(parentItem["ColorStatus"].ToString()) >= 1)
                    {
                        subParentItem.ImageUrl = @"~/Images/Tick.png";
                        subParentItem.ForeColor = Color.Red;
                    }
                    else
                    {
                        subParentItem.ForeColor = Color.Empty;
                        subParentItem.ImageUrl = @"~/Images/Desktop.png";
                    }
                    mainItem.Nodes.Add(subParentItem);
                }
            }
            tvMenu.ExpandAllNodes();
            if (tvMenu.CheckChildNodes)
            {
                tvMenu.Nodes[0].Expanded = true;
            }
        }

        /// <summary>
        /// Termination Type Drop down list selected index changed event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Rad Combo Box Selected Index Changed Event Args</param>
        protected void ddlTerminationType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            FillddlSortedBy();
        }

        /// <summary>
        /// drop down sorting order selected index changed event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">Event args</param>
        protected void ddlSortedBy_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ViewState["ChangedTerminationDetail"] = null;
            ddlSelectedItems.Items.Clear();
            gvSaleTermination.DataSource = null;
            gvSaleTermination.DataBind();
            FillMenu();
        }

        /// <summary>
        /// Tree View or Termination Navigation Menu Node click Event.
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Rad Tree Node Event Args</param>
        protected void tvMenu_NodeClick(object sender, RadTreeNodeEventArgs e)
        {
            ViewState["ChangedTerminationDetail"] = null;
            ddlSelectedItems.Items.Clear();
            FillddlSelectedItems(e.Node.Text, e.Node.Value);
        }

        /// <summary>
        /// Tree View or Termination Navigation Menu Node Drop Event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Rad Tree Node Drag Drop Event Args</param>
        protected void tvMenu_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
        {
            ViewState["ChangedTerminationDetail"] = null;
            FillddlSelectedItems(e.SourceDragNode.Text, e.SourceDragNode.Value);
        }

        /// <summary>
        /// bind drop down selected item
        /// </summary>
        /// <param name="text">drop down text property</param>
        /// <param name="value">drop down value property</param>
        protected void FillddlSelectedItems(string text, string value)
        {
            var items = new RadComboBoxItem();
            if (ddlSelectedItems.FindItemByValue(value) == null)
            {
                items.Text = text;
                items.Value = value;
                items.Checked = true;
                ddlSelectedItems.Items.Add(items);
                FillgvSaleTermination();
            }
            else
            {
                Show("item already in the list");
            }
        }

        /// <summary>
        /// drop down list selected item checked event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Rad Combo Box Item Event Args</param>
        protected void ddlSelectedItems_ItemChecked(object sender, RadComboBoxItemEventArgs e)
        {
            ViewState["ChangedTerminationDetail"] = null;
            if (e.Item.Checked == false)
            {
                RadComboBoxItem items = ddlSelectedItems.FindItemByValue(e.Item.Value);
                ddlSelectedItems.Items.Remove(items);
                FillgvSaleTermination();
            }
        }

        /// <summary>
        /// Bind Sale Termination Grid
        /// </summary>
        protected void FillgvSaleTermination()
        {
            var objOperationManagement = new BL.OperationManagement();
            var codeDetails = string.Empty;

            for (var i = 0; i < ddlSelectedItems.Items.Count; i++)
            {
                codeDetails = codeDetails + ddlSelectedItems.Items[i].Value + ",";
            }

            using (
                DataSet ds = objOperationManagement.SaleTerminationDetailsGet(BaseLocationAutoID, codeDetails,
                    ddlTerminationType.SelectedValue))
            {
                ViewState["TerminationDetail"] = null;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //var dt = ds.Clone();
                    //dt.Columns["WEFDate"].DataType = typeof(String);

                    ViewState["TerminationDetail"] = ds.Tables[0];
                    var dv = new DataView(ds.Tables[0]) {RowFilter = "TerminationStatus='Save'"};
                    var dataTable = dv.ToTable();

                    lblStatus.Text = dataTable.Rows.Count > 0 ? Resources.Resource.Fresh : string.Empty;

                    gvSaleTermination.DataSource = ds.Tables[0];
                    gvSaleTermination.DataBind();
                    //UpdatePanel1.Update();
                }
                else
                {
                    gvSaleTermination.DataSource = null;
                    gvSaleTermination.DataBind();
                }
            }
        }

        /// <summary>
        /// Sale Termination Grid Data Bound Event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">Event Args</param>
        protected void gvSaleTermination_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = "javascript:showRowID(" + e.Row.RowIndex + "," +
                                              gvSaleTermination.PageIndex + "," +
                                              gvSaleTermination.PageSize + ");";
                var lblSoStatus = (Label) e.Row.FindControl("lblSoStatus");
                var lblTerminationReason = (Label) e.Row.FindControl("lblTerminationReason");
                var lblWefDate = (Label) e.Row.FindControl("lblWEFDate");
                var hfTerminationStatus = (HiddenField) e.Row.FindControl("HFTerminationStatus");
                var cbActive = (CheckBox) e.Row.FindControl("cbActive");
                var hfMinActDate = (HiddenField) e.Row.FindControl("HFMinActDate");
                var hfMaxActDate = (HiddenField) e.Row.FindControl("HFMaxActDate");
                var hfMinSchDate = (HiddenField) e.Row.FindControl("HFMinSchDate");
                var hfMaxSchDate = (HiddenField) e.Row.FindControl("HFMaxSchDate");
                var hfMinRotaAuthorizedDate = (HiddenField) e.Row.FindControl("HFMinRotaAuthorizedDate");
                var hfMaxRotaAuthorizedDate = (HiddenField) e.Row.FindControl("HFMaxRotaAuthorizedDate");
                var hfAttendanceDeleteStatus = (HiddenField) e.Row.FindControl("HFAttendanceDeleteStatus");

                var lbRotaStatus = (LinkButton) e.Row.FindControl("lbRotaStatus");

                if (lblSoStatus != null)
                {
                    if (lblSoStatus.Text.ToLower() == "AMEND".ToLower() ||
                        lblSoStatus.Text.ToLower() == "Fresh".ToLower())
                    {
                        e.Row.BackColor = Color.Red;
                        lblTerminationReason.Text = Resources.Resource.SaleOrderNotAuthorized;
                        if (cbActive != null)
                        {
                            cbActive.Enabled = false;
                        }
                    }

                }
                if (cbActive != null)
                {
                    if (cbActive.Checked == false)
                    {
                        cbActive.Enabled = false;
                        e.Row.BackColor = Color.Aqua;
                    }
                    else
                    {
                        cbActive.Enabled = true;
                        e.Row.BackColor = Color.Empty;
                    }
                }
                if (lblWefDate != null)
                {
                    if (lblWefDate.Text != string.Empty)
                    {
                        lblWefDate.Text = DateTime.Parse(lblWefDate.Text) == DateTime.Parse("01-01-1900")
                            ? string.Empty
                            : DateTime.Parse(lblWefDate.Text).ToString(Resources.Resource.ScheduleDefaultDateFormat);

                        if (lblWefDate.Text != string.Empty)
                        {
                            if (hfMinRotaAuthorizedDate.Value != string.Empty)
                            {
                                //if (DateTime.Parse(lblWEFDate.Text) >= DateTime.Parse(HFMinRotaAuthorizedDate.Value) && DateTime.Parse(lblWEFDate.Text) <= DateTime.Parse(HFMaxRotaAuthorizedDate.Value))
                                if (DateTime.Parse(lblWefDate.Text) >= DateTime.Parse(hfMinRotaAuthorizedDate.Value) &&
                                    DateTime.Parse(lblWefDate.Text) < DateTime.Parse(hfMaxRotaAuthorizedDate.Value))
                                {
                                    lbRotaStatus.Text = Resources.Resource.AnyoperationisnotallowedonAuthorizedRota;
                                    // return;
                                }
                            }

                            if (hfMinActDate.Value != string.Empty)
                            {
                                if (DateTime.Parse(lblWefDate.Text) <= DateTime.Parse(hfMinActDate.Value) ||
                                    DateTime.Parse(lblWefDate.Text) <= DateTime.Parse(hfMaxActDate.Value))
                                {
                                    lbRotaStatus.Text = Resources.Resource.RotaExistsDeleteRotafirst;
                                    if (hfAttendanceDeleteStatus != null && hfAttendanceDeleteStatus.Value == "1")
                                    {
                                        lbRotaStatus.ForeColor = Color.Green;
                                    }
                                    else
                                    {
                                        lbRotaStatus.ForeColor = Color.Black;
                                    }
                                }
                            }

                            if (hfMinSchDate.Value != string.Empty)
                            {
                                if (DateTime.Parse(lblWefDate.Text) <= DateTime.Parse(hfMinSchDate.Value) ||
                                    DateTime.Parse(lblWefDate.Text) <= DateTime.Parse(hfMaxSchDate.Value))
                                {
                                    lbRotaStatus.Text = Resources.Resource.RotaExistsDeleteRotafirst;
                                    if (hfAttendanceDeleteStatus != null && hfAttendanceDeleteStatus.Value == "1")
                                    {
                                        lbRotaStatus.ForeColor = Color.Green;
                                    }
                                    else
                                    {
                                        lbRotaStatus.ForeColor = Color.Black;
                                    }
                                }
                            }
                        }
                    }
                }
                if (hfTerminationStatus != null)
                {
                    if (hfTerminationStatus.Value != string.Empty)
                    {
                        if (hfTerminationStatus.Value.ToLower() == "Save".ToLower())
                        {
                            e.Row.BackColor = Color.Khaki;
                        }
                    }
                }



                if (hfAttendanceDeleteStatus != null)
                {
                    if (hfAttendanceDeleteStatus.Value == "0")
                    {
                        lbRotaStatus.Visible = true;
                        HFRotaDeleteStatus.Value = "1";
                    }
                    else
                    {
                        lbRotaStatus.Visible = false;
                        if (HFRotaDeleteStatus.Value != "1")
                        {
                            HFRotaDeleteStatus.Value = string.Empty;
                        }
                    }
                }

            }
        }


        /// <summary>
        /// Update button event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void btnGridUpdate_Click(object sender, EventArgs e)
        {
            EnableCheckBox();
        }

        /// <summary>
        /// Save Button event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            HFCurrentRowIndex.Value = string.Empty;
            SaveData();
            FillMenu();
        }

        /// <summary>
        /// Authorize button event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void btnAuthorize_Click(object sender, EventArgs e)
        {
            var objPretermination = new BL.PreTermination();
            if (ViewState["TerminationDetail"] != null)
            {
                var dt = (DataTable) ViewState["TerminationDetail"];
                var dv = new DataView(dt);
                dv.RowFilter = "Active = 0";
                if (dt != null && dv.Count > 0)
                {
                    var ds = new DataSet();
                    ds.Tables.Add(dt);
                    using (DataSet termination = objPretermination.TerminateSaleOrder(ds.GetXml(), "AUTHORIZED", BaseLocationAutoID, BaseUserID))
                    {
                        dv.RowFilter = "Active = 0 AND AttendanceDeleteStatus = 0";
                        if (dv.Count > 0)
                        {
                            DisplayMessageString(lblErrorMsg, Resources.Resource.RotaExistsDeleteRotafirst);
                            FillgvSaleTermination();
                        }
                        else if (termination != null && termination.Tables.Count > 0 && termination.Tables[0].Rows.Count > 0)
                        {
                            int tblindex = termination.Tables.Count - 1;
                            if (termination.Tables[tblindex].Rows[0]["MessageID"].ToString() == "150")
                            {
                                DisplayMessage(lblErrorMsg, termination.Tables[tblindex].Rows[0]["MessageID"].ToString());
                                FillgvSaleTermination();
                            }
                            else
                            {
                                DisplayMessage(lblErrorMsg, termination.Tables[tblindex].Rows[0]["MessageID"].ToString());
                                FillgvSaleTermination();
                                FillMenu();
                            }
                        }
                    }
                }
                else
                {
                    FillgvSaleTermination();
                    //btnAuthorize_Click(sender, e);
                    lblErrorMsg.Text = string.Empty;
                }
            }

        }

        /// <summary>
        /// rollback termination button click event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void btnRollBackTermination_Click(object sender, EventArgs e)
        {
            var objPretermination = new BL.PreTermination();
            if (ViewState["TerminationDetail"] != null)
            {
                var dt = (DataTable) ViewState["TerminationDetail"];

                var dv = new DataView(dt);
                dv.RowFilter = "Active = 0";
                if (dt != null && dv.Count > 0)
                {
                    var ds = new DataSet();
                    ds.Tables.Add(dt);
                    using (
                        DataSet termination = objPretermination.TerminateSaleOrder(ds.GetXml(), "RollBack",
                            BaseLocationAutoID, BaseUserID))
                    {
                        if (termination.Tables[0].Rows[0]["MessageID"].ToString() == "0")
                        {
                            lblErrorMsg.Text = Resources.Resource.MsgUnknownError;
                            FillgvSaleTermination();
                        }
                        else
                        {
                            DisplayMessage(lblErrorMsg, termination.Tables[0].Rows[0]["MessageID"].ToString());
                            ViewState["TerminationDetail"] = null;
                            ViewState["ChangedTerminationDetail"] = null;
                            FillgvSaleTermination();
                        }
                    }
                }
                else
                {
                    lblErrorMsg.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Bulk Save button click event
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void btnBulkSave_Click(object sender, EventArgs e)
        {
            //ViewState["ChangedTerminationDetail"] = null;
            string value = SaveButtonText.Value;
            if (value == "Bulk")
            {
                for (int i = 0; i < gvSaleTermination.Rows.Count; i++)
                {
                    AssignWefAndTerminationReason(i.ToString());
                }
            }
            else if (value == "Single")
            {
                var rowIndex = HFRowIndex.Value;
                if (rowIndex != string.Empty && int.Parse(rowIndex) >= 0)
                {
                    AssignWefAndTerminationReason(rowIndex);
                }
            }
            ClearTerminationReasonTextFields();
        }
        /// <summary>
        /// Clear Termination Region Text
        /// </summary>
        protected void ClearTerminationReasonTextFields()
        {
            txtTerminationReason.Text = string.Empty;
            txtWithEffectiveDate.Text = string.Empty;
        }

        /// <summary>
        /// Save Records to Pre Termination
        /// </summary>
        protected void SaveData()
        {
            var objTermination = new BL.PreTermination();
            var dt = (DataTable) ViewState["ChangedTerminationDetail"];
            if (dt != null && dt.Rows.Count > 0)
            {
                var ds = new DataSet();
                ds.Tables.Add(dt);
                using (DataSet dsTermination = objTermination.PreTerminationInsert(ds.GetXml(),
                        ddlTerminationType.SelectedValue, "Save", BaseUserID))
                {
                    if (dsTermination != null && dsTermination.Tables.Count > 0 && dsTermination.Tables[0].Rows.Count>0)
                    {
                        DisplayMessage(lblErrorMsg, dsTermination.Tables[0].Rows[0]["MessageID"].ToString());
                    }
                    FillgvSaleTermination();
                    ViewState["ChangedTerminationDetail"] = null;
                }
            }
        }

        /// <summary>
        /// Assign Wef Date and Reason of Termination.
        /// </summary>
        /// <param name="rowIndex">grid row index</param>
        protected void AssignWefAndTerminationReason(string rowIndex)
        {
            var lblWefDate = (Label) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("lblWEFDate");
            var hfSoLineWefDate =
                (HiddenField) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("HFSoLineWefDate");
            var lblSoLineEndDate = (Label) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("lblSOLineEndDate");
            var lblTerminationReason =
                (Label) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("lblTerminationReason");
            var cbActive = (CheckBox) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("cbActive");
            var hfRowNumber = (HiddenField) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("HFRowNumber");
            var hfMinActDate = (HiddenField) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("HFMinActDate");
            var hfMaxActDate = (HiddenField) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("HFMaxActDate");
            var hfMinSchDate = (HiddenField) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("HFMinSchDate");
            var hfMaxSchDate = (HiddenField) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("HFMaxSchDate");
            var hfMinRotaAuthorizedDate =
                (HiddenField) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("HFMinRotaAuthorizedDate");
            var hfMaxRotaAuthorizedDate =
                (HiddenField) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("HFMaxRotaAuthorizedDate");
            var lbRotaStatus = (LinkButton) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("lbRotaStatus");
            var lblSoStatus = (Label) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("lblSoStatus");

            if (lblSoStatus.Text.ToLower() == "AMEND".ToLower() || lblSoStatus.Text.ToLower() == "Fresh".ToLower())
            {
                gvSaleTermination.Rows[int.Parse(rowIndex)].BackColor = Color.Red;
                lblTerminationReason.Text = Resources.Resource.SaleOrderNotAuthorized;
                return;
            }


            if (hfMinRotaAuthorizedDate.Value != string.Empty)
            {
                if (//DateTime.Parse(txtWithEffectiveDate.Text) >= DateTime.Parse(hfMinRotaAuthorizedDate.Value) &&
                    DateTime.Parse(txtWithEffectiveDate.Text) < DateTime.Parse(hfMaxRotaAuthorizedDate.Value))
                {
                    Show(Resources.Resource.AnyoperationisnotallowedonAuthorizedRota);
                    FillgvSaleTermination();
                    UpdatePanel1.Update();
                    return;
                }
            }

            if (hfMinActDate.Value != string.Empty)
            {
                if (DateTime.Parse(txtWithEffectiveDate.Text) <= DateTime.Parse(hfMinActDate.Value) ||
                    DateTime.Parse(txtWithEffectiveDate.Text) <= DateTime.Parse(hfMaxActDate.Value))
                {
                    lbRotaStatus.Text = Resources.Resource.RotaExistsDeleteRotafirst;
                    //lbRotaStatus.Visible = true;
                    HFRotaDeleteStatus.Value = "1";
                }
            }

            if (hfMinSchDate.Value != string.Empty)
            {
                if (DateTime.Parse(txtWithEffectiveDate.Text) <= DateTime.Parse(hfMinSchDate.Value) ||
                    DateTime.Parse(txtWithEffectiveDate.Text) <= DateTime.Parse(hfMaxSchDate.Value))
                {
                    lbRotaStatus.Text = Resources.Resource.RotaExistsDeleteRotafirst;
                    //lbRotaStatus.Visible = true;
                    HFRotaDeleteStatus.Value = "1";
                }
            }

            var dt = (DataTable) ViewState["TerminationDetail"];
            DataRow[] terminatedRow = dt.Select("RowNumber = '" + hfRowNumber.Value + "'");

            if (//DateTime.Parse(txtWithEffectiveDate.Text) >= DateTime.Parse(hfSoLineWefDate.Value) &&
                DateTime.Parse(txtWithEffectiveDate.Text) <= DateTime.Parse(lblSoLineEndDate.Text))
            {
                cbActive.Checked = false;
                lblWefDate.Text = txtWithEffectiveDate.Text;
                lblTerminationReason.Text = txtTerminationReason.Text;
                cbActive.Enabled = false;


                terminatedRow[0]["WithEffectiveDate"] =
                    DateTime.Parse(lblWefDate.Text).ToString(Resources.Resource.ScheduleDefaultDateFormat);
                terminatedRow[0]["TerminationReason"] = lblTerminationReason.Text;
                terminatedRow[0]["Active"] = cbActive.Checked;
                gvSaleTermination.Rows[int.Parse(rowIndex)].BackColor = Color.Aqua;
            }
            else
            {
                cbActive.Enabled = true;
                cbActive.Checked = true;
                gvSaleTermination.Rows[int.Parse(rowIndex)].BackColor = Color.Red;
            }

            DataTable newTable;
            if (ViewState["ChangedTerminationDetail"] == null)
            {
                newTable = dt.GetChanges();

            }
            else
            {
                newTable = (DataTable) ViewState["ChangedTerminationDetail"];
                var dataTable = dt.GetChanges();
                if (dataTable != null)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        newTable.ImportRow(dataTable.Rows[i]);
                    }
                }
            }
            ViewState["ChangedTerminationDetail"] = newTable;
            dt.AcceptChanges();
            ViewState["TerminationDetail"] = dt;
            UpdatePanel1.Update();

        }

        /// <summary>
        /// Cancel Button Click Event for Schedule and Actual Rota Popup
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EnableCheckBox();
            ClearTerminationReasonTextFields();
        }

        /// <summary>
        /// Enable the checkbox
        /// </summary>
        protected void EnableCheckBox()
        {
            //if (HFClickStatus.Value == "Single")
            //{
                var rowIndex = HFRowIndex.Value;
                if (!string.IsNullOrEmpty(rowIndex))
                {
                    if (int.Parse(rowIndex) >= 0)
                    {
                        var cbActive = (CheckBox) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("cbActive");
                        var lblWefDate = (Label) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("lblWEFDate");
                        var lblTerminationReason =
                            (Label) gvSaleTermination.Rows[int.Parse(rowIndex)].FindControl("lblTerminationReason");
                        if (cbActive != null)
                        {
                            if (cbActive.Checked == false)
                            {
                                cbActive.Checked = true;
                                //lblWefDate.Text = txtWithEffectiveDate.Text;
                                //lblTerminationReason.Text = txtTerminationReason.Text;
                                lblWefDate.Text = string.Empty;
                                lblTerminationReason.Text = string.Empty;
                                gvSaleTermination.Rows[int.Parse(rowIndex)].BackColor = Color.Empty;
                            }
                            else
                            {
                                lblWefDate.Text = string.Empty;
                                lblTerminationReason.Text = string.Empty;
                                gvSaleTermination.Rows[int.Parse(rowIndex)].BackColor = Color.Empty;
                            }
                            UpdatePanel1.Update();
                        }
                    }
                }
            //}
        }

        /// <summary>
        /// click event of link button Rota Status in Grid
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void lbRotaStatus_Click(object sender, EventArgs e)
        {
            var objLinkButton = (LinkButton) sender;
            var row = (GridViewRow) objLinkButton.NamingContainer;
            var lblSono = (Label) gvSaleTermination.Rows[row.RowIndex].FindControl("lblSONO");
            var lblSoLineNo = (Label) gvSaleTermination.Rows[row.RowIndex].FindControl("lblSOLineNo");
            var hfPostAutoId = (HiddenField) gvSaleTermination.Rows[row.RowIndex].FindControl("HFPostAutoID");
            var lblWefDate = (Label) gvSaleTermination.Rows[row.RowIndex].FindControl("lblWEFDate");
            HFCurrentRowIndex.Value = lblStatus.Text == string.Empty ? row.RowIndex.ToString() : string.Empty;
            HfASSoNo.Value = lblSono.Text;
            HfASSoLineNo.Value = lblSoLineNo.Text;
            HfASPostAutoId.Value = hfPostAutoId.Value;
            HfASWEFDate.Value = lblWefDate.Text;
            FillgvScheduleRoster();
            FillgvDeleteRota();
            mdlPopup.Show();
        }

        #region Delete Schedule and actual Duty

        /// <summary>
        /// Handles the RowCommand event of the gvScheduleRoster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
        protected void gvScheduleRoster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandArgument.ToString())
            {
                case "First":
                    gvScheduleRoster.PageIndex = 0;
                    break;
                case "Prev":
                    staticIndex = 1;
                    break;
                case "Next":
                    staticIndex = 0;
                    break;
                case "Last":
                    gvScheduleRoster.PageIndex = gvScheduleRoster.PageCount;
                    break;
            }
        }

        /// <summary>
        /// Handles the DataBound event of the gvScheduleRoster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void gvScheduleRoster_DataBound(object sender, EventArgs e)
        {
            GridViewRow row = gvScheduleRoster.BottomPagerRow;
            if (row == null)
            {
                return;
            }
            var ddlPages = (DropDownList) row.Cells[0].FindControl("ddlPages");
            var lblPageCount = (Label) row.Cells[0].FindControl("lblPageCount");
            if (ddlPages != null)
            {
                for (int i = 0; i < gvScheduleRoster.PageCount; i++)
                {
                    int intPageNumber = i + 1;
                    var lstItem = new ListItem(intPageNumber.ToString());
                    if (i == gvScheduleRoster.PageIndex)
                    {
                        lstItem.Selected = true;
                    }
                    ddlPages.Items.Add(lstItem);
                }
            }
            if (lblPageCount != null)
            {
                lblPageCount.Text = gvScheduleRoster.PageCount.ToString();
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvScheduleRoster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
        protected void gvScheduleRoster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewRow gvrPager = gvScheduleRoster.BottomPagerRow;
            var ddlPages = (DropDownList) gvrPager.Cells[0].FindControl("ddlPages");
            int currentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
            if (staticIndex == 1)
            {
                if (currentIndex > 0)
                {
                    gvScheduleRoster.PageIndex = currentIndex - 1;
                }
                else
                {
                    gvScheduleRoster.PageIndex = currentIndex;
                }
                staticIndex = -1;
            }
            else if (staticIndex == 0)
            {
                gvScheduleRoster.PageIndex = currentIndex + 1;
                staticIndex = -1;
            }
            else
            {
                gvScheduleRoster.PageIndex = e.NewPageIndex;
            }
            FillgvScheduleRoster();
            //UpdatePanelDeleteRota.Update();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddlPagesDeleteRota control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void ddlPagesDeleteRota_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvDeleteRota.BottomPagerRow;
            var ddlPagesDeleteRota = (DropDownList) row.Cells[0].FindControl("ddlPagesDeleteRota");
            gvDeleteRota.PageIndex = ddlPagesDeleteRota.SelectedIndex;
            FillgvDeleteRota();
        }

        /// <summary>
        /// Handles the RowCommand event of the gvDeleteRota control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewCommandEventArgs" /> instance containing the event data.</param>
        protected void gvDeleteRota_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandArgument.ToString())
            {
                case "First":
                    gvDeleteRota.PageIndex = 0;
                    break;
                case "Prev":
                    staticIndex = 1;
                    break;
                case "Next":
                    staticIndex = 0;
                    break;
                case "Last":
                    gvDeleteRota.PageIndex = gvDeleteRota.PageCount;
                    break;
            }
        }

        /// <summary>
        /// Handles the DataBound event of the gvDeleteRota control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void gvDeleteRota_DataBound(object sender, EventArgs e)
        {
            GridViewRow row = gvDeleteRota.BottomPagerRow;
            if (row == null)
            {
                return;
            }
            var ddlPagesDeleteRota = (DropDownList) row.Cells[0].FindControl("ddlPagesDeleteRota");
            var lblPageCountDeleteRota = (Label) row.Cells[0].FindControl("lblPageCountDeleteRota");
            if (ddlPagesDeleteRota != null)
            {
                for (int i = 0; i < gvDeleteRota.PageCount; i++)
                {
                    int intPageNumber = i + 1;
                    var lstItem = new ListItem(intPageNumber.ToString());
                    if (i == gvDeleteRota.PageIndex)
                    {
                        lstItem.Selected = true;
                    }
                    ddlPagesDeleteRota.Items.Add(lstItem);
                }
            }
            if (lblPageCountDeleteRota != null)
            {
                lblPageCountDeleteRota.Text = gvDeleteRota.PageCount.ToString();
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gvDeleteRota control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="GridViewPageEventArgs" /> instance containing the event data.</param>
        protected void gvDeleteRota_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var gvrPager = gvDeleteRota.BottomPagerRow;
            var ddlPages = (DropDownList) gvrPager.Cells[0].FindControl("ddlPagesDeleteRota");
            var currentIndex = int.Parse(ddlPages.SelectedItem.Text) - 1;
            switch (staticIndex)
            {
                case 1:
                    if (currentIndex > 0)
                    {
                        gvDeleteRota.PageIndex = currentIndex - 1;
                    }
                    else
                    {
                        gvDeleteRota.PageIndex = currentIndex;
                    }
                    staticIndex = -1;
                    break;
                case 0:
                    gvDeleteRota.PageIndex = currentIndex + 1;
                    staticIndex = -1;
                    break;
                default:
                    gvDeleteRota.PageIndex = e.NewPageIndex;
                    break;
            }
            gvDeleteRota.EditIndex = -1;
            FillgvDeleteRota();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ddlPages control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            var row = gvScheduleRoster.BottomPagerRow;
            var ddlPages = (DropDownList) row.Cells[0].FindControl("ddlPages");
            gvScheduleRoster.PageIndex = ddlPages.SelectedIndex;
            FillgvScheduleRoster();
        }

        /// <summary>
        /// Handles the onClick event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnDelete_onClick(object sender, EventArgs e)
        {
            if (HfASSoNo.Value != string.Empty && HfASSoLineNo.Value != string.Empty &&
                HfASPostAutoId.Value != string.Empty && HfASWEFDate.Value != string.Empty)
            {
                //----------Update the Viwstate data set attandance status
                DataTable dt;
                if (ViewState["ChangedTerminationDetail"] == null)
                {
                    dt = (DataTable) ViewState["TerminationDetail"];
                }
                else
                {
                    dt = (DataTable) ViewState["ChangedTerminationDetail"];
                }
                var terminatedRow =
                    dt.Select("SoNo = '" + HfASSoNo.Value + "' AND SoLineNo = '" + HfASSoLineNo.Value + "'");
                terminatedRow[0]["AttendanceDeleteStatus"] = true;
                terminatedRow[0]["Active"] = false;
                dt.AcceptChanges();
                ViewState["ChangedTerminationDetail"] = dt;

                //----------------------------------------

                var objPreTermination = new BL.PreTermination();
                var ds = objPreTermination.PreTerminationRotaScheduleDeleteStatusUpdate(HfASSoNo.Value,
                    HfASSoLineNo.Value, HfASPostAutoId.Value, DateTime.Parse(HfASWEFDate.Value));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DisplayMessage(lblErrorMsg, ds.Tables[0].Rows[0]["MessageID"].ToString());
                }
            }
            mdlPopup.Hide();
            FillgvSaleTermination();
            HFRotaDeleteStatus.Value = "0";
            if (HFCurrentRowIndex.Value != string.Empty)
            {
                var cbActive =
                    (CheckBox) gvSaleTermination.Rows[int.Parse(HFCurrentRowIndex.Value)].FindControl("cbActive");
                cbActive.Checked = false;
                gvSaleTermination.Rows[int.Parse(HFCurrentRowIndex.Value)].BackColor = Color.Aqua;
            }
        }

        /// <summary>
        /// Handles the onClick event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected void btnCancel_onClick(object sender, EventArgs e)
        {

            mdlPopup.Hide();
        }

        /// <summary>
        /// Fill grid view the schedule roster.
        /// </summary>
        private void FillgvScheduleRoster()
        {
            if (HfASSoNo.Value != string.Empty && HfASSoLineNo.Value != string.Empty &&
                HfASPostAutoId.Value != string.Empty && HfASWEFDate.Value != string.Empty)
            {
                var objPreTermination = new BL.PreTermination();
                var ds = objPreTermination.ScheduleGet(HfASSoNo.Value, HfASSoLineNo.Value, HfASPostAutoId.Value,
                    DateTime.Parse(HfASWEFDate.Value));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvScheduleRoster.DataSource = ds.Tables[0];
                    gvScheduleRoster.DataBind();
                }
                else
                {
                    gvScheduleRoster.DataSource = null;
                    gvScheduleRoster.DataBind();
                }
            }
        }

        /// <summary>
        /// Fill grid view delete rota.
        /// </summary>
        private void FillgvDeleteRota()
        {
            if (HfASSoNo.Value != string.Empty && HfASSoLineNo.Value != string.Empty &&
                HfASPostAutoId.Value != string.Empty && HfASWEFDate.Value != string.Empty)
            {
                var objPreTermination = new BL.PreTermination();
                var ds = objPreTermination.RotaGet(HfASSoNo.Value, HfASSoLineNo.Value, HfASPostAutoId.Value,
                    DateTime.Parse(HfASWEFDate.Value));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvDeleteRota.DataSource = ds.Tables[0];
                    gvDeleteRota.DataBind();
                }
                else
                {
                    gvDeleteRota.DataSource = null;
                    gvDeleteRota.DataBind();
                }
            }
        }

        #endregion Delete Schedule and actual Duty
    }
}