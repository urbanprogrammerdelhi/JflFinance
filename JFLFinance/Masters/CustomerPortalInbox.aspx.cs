// ***********************************************************************
// Assembly         :
// Author           : manish
// Created          : 09-13-2013
//
// Last Modified By : manish
// Last Modified On : 03-21-2014
// ***********************************************************************
// <copyright file="CustomerPortalInbox.aspx.cs" company="Magnon">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Data;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

/// <summary>
/// Customer portal Inbox
/// </summary>
public partial class Masters_CustomerPortalInbox : BasePage
{
    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.FillgvChangeRequestInbox();
            gvChangeRequestInbox.DataBind();
            if (gvChangeRequestInbox.Items.Count > 0)
            {
                gvChangeRequestInbox.MasterTableView.Items[0].Selected = true;
                var hfGuid = (HiddenField)gvChangeRequestInbox.Items[0].FindControl("hfGuid");
                var hfRequestType = (HiddenField)gvChangeRequestInbox.Items[0].FindControl("hfRequestType");
                this.CustomerChangeRequestGetDetails(hfGuid, hfRequestType);
            }
        }
    }

    /// <summary>
    /// Handles the NeedDataSource event of the gvChangeRequestInbox control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridNeedDataSourceEventArgs" /> instance containing the event data.</param>
    protected void gvChangeRequestInbox_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        this.FillgvChangeRequestInbox();
    }

    /// <summary>
    /// Handles the ItemCommand event of the gvChangeRequestInbox control.
    /// </summary>
    /// <param name="source">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.GridCommandEventArgs" /> instance containing the event data.</param>
    protected void gvChangeRequestInbox_ItemCommand(object source, GridCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "RowClick":
                var dataItem = e.Item as GridDataItem;

                if (dataItem != null)
                {
                    var hfGuid = (HiddenField)dataItem.FindControl("hfGuid");
                    var hfRequestType = (HiddenField)dataItem.FindControl("hfRequestType");
                    if (hfRequestType != null)
                    {
                        hfTypeOfRequest.Value = hfRequestType.Value;
                        hfRequestGuid.Value = hfGuid.Value;
                        this.CustomerChangeRequestGetDetails(hfGuid, hfRequestType);
                    }
                }

                break;
        }
    }

    /// <summary>
    /// Handles the ButtonClick event of the MessageToolbar control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="Telerik.Web.UI.RadToolBarEventArgs" /> instance containing the event data.</param>
    protected void MessageToolbar_ButtonClick(object sender, RadToolBarEventArgs e)
    {
        var objPortal = new BL.Portal();
        var button = e.Item as RadToolBarButton;
        if (button != null)
        {
            using (DataSet dml = objPortal.CustomerChangeRequestDetailUpdate(this.hfRequestGuid.Value, this.hfTypeOfRequest.Value, this.lblAuthorizedByComment.Text, button.CommandName, this.BaseUserID))
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }
        }
        this.FillgvChangeRequestInbox();
        gvChangeRequestInbox.DataBind();
    }

    /// <summary>
    /// Fillgvs the change request inbox.
    /// </summary>
    private void FillgvChangeRequestInbox()
    {
        var portal = new BL.Portal();
        using (DataSet portalInboxDetails = portal.CustomerInboxDetailsGet(BaseIsAdmin, BaseUserID, BaseLocationAutoID))
        {
            if (portalInboxDetails != null && portalInboxDetails.Tables.Count > 0)
            {
                gvChangeRequestInbox.DataSource = portalInboxDetails.Tables[0];
            }
        }
    }

    /// <summary>
    /// Hides the type of the show panel based on request.
    /// </summary>
    /// <param name="requestType">Type of the request.</param>
    private void HideShowPanelBasedOnRequestType(HiddenField requestType)
    {
        panelCustomerDetails.Visible = false;
        panelCustomerConstraint.Visible = false;
        panelAssignment.Visible = false;
        panelDeployment.Visible = false;
        if (requestType.Value == "CustomerType")
        {
            panelCustomerDetails.Visible = true;
        }
        else if (requestType.Value == "CustomerConstraintType" || requestType.Value == "Language" || requestType.Value == "Qualification" || requestType.Value == "SaleConstraint" || requestType.Value == "Training")
        {
            panelCustomerConstraint.Visible = true;
        }
        else if (requestType.Value == "Assignment")
        {
            panelAssignment.Visible = true;
        }
        else if (requestType.Value == "Deployment")
        {
            panelDeployment.Visible = true;
        }
    }

    /// <summary>
    /// Hides the button based on status.
    /// </summary>
    /// <param name="authorizationStatus">The authorization status.</param>
    private void HideButtonBasedOnStatus(string authorizationStatus)
    {
        if (authorizationStatus.ToLower() == "Pending".ToLower())
        {
            btnApprove.Visible = true;
            btnReject.Visible = true;
        }
        else
        {
            btnApprove.Visible = false;
            btnReject.Visible = false;
        }
    }

    /// <summary>
    /// Customers the change request get details.
    /// </summary>
    /// <param name="guid">The GUID.</param>
    /// <param name="requestType">Type of the request.</param>
    private void CustomerChangeRequestGetDetails(HiddenField guid, HiddenField requestType)
    {
        var objPortal = new BL.Portal();
        this.HideShowPanelBasedOnRequestType(requestType);
       
        using (DataSet getDetails = objPortal.CustomerChangeRequestGetDetails(guid.Value, requestType.Value))
        {
            if (getDetails != null && getDetails.Tables[0].Rows.Count > 0 && getDetails.Tables.Count > 0)
            {
                this.HideButtonBasedOnStatus(getDetails.Tables[0].Rows[0]["AuthorizationStatus"].ToString());
                lblReceiver.Text = @"Dear" + @" " + BaseUserName + @",";
                //// lblSender.Text = getDetails.Tables[0].Rows[0]["ModifiedBy"].ToString();
                lblMessage.Text = @"Customer have requested to modify below mention details. ";

                if (requestType.Value == "CustomerType")
                {

                    lblOldAddress1.Text = getDetails.Tables[0].Rows[0]["OldAddress1"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewAddress1"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewAddress1"].ToString() == string.Empty)
                    {
                        lblNewAddress1.Text = @"No Change";
                        lblNewAddress1.ForeColor = System.Drawing.Color.Empty;
                        lblNewAddress1.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAddress1.Text = getDetails.Tables[0].Rows[0]["NewAddress1"].ToString();
                        lblNewAddress1.ForeColor = System.Drawing.Color.Red;
                        lblNewAddress1.Font.Bold = true;
                    }

                    lblOldAddress2.Text = getDetails.Tables[0].Rows[0]["OldAddress2"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewAddress2"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewAddress2"].ToString() == string.Empty)
                    {
                        lblNewAddress2.Text = @"No Change";
                        lblNewAddress2.ForeColor = System.Drawing.Color.Empty;
                        lblNewAddress2.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAddress2.Text = getDetails.Tables[0].Rows[0]["NewAddress2"].ToString();
                        lblNewAddress2.ForeColor = System.Drawing.Color.Red;
                        lblNewAddress2.Font.Bold = true;
                    }

                    lblOldAddress3.Text = getDetails.Tables[0].Rows[0]["OldAddress3"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewAddress3"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewAddress3"].ToString() == string.Empty)
                    {
                        lblNewAddress3.Text = @"No Change";
                        lblNewAddress3.ForeColor = System.Drawing.Color.Empty;
                        lblNewAddress3.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAddress3.Text = getDetails.Tables[0].Rows[0]["NewAddress3"].ToString();
                        lblNewAddress3.ForeColor = System.Drawing.Color.Red;
                        lblNewAddress3.Font.Bold = true;
                    }

                    lblOldZip.Text = getDetails.Tables[0].Rows[0]["OldZipCode"].ToString();
                    lblOldGroupZip.Text = getDetails.Tables[0].Rows[0]["OldGroupZipCode"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewZipCode"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewZipCode"].ToString() == string.Empty)
                    {
                        lblNewZip.Text = @"No Change";
                        lblNewZip.ForeColor = System.Drawing.Color.Empty;
                        lblNewZip.Font.Bold = false;
                    }
                    else
                    {
                        lblNewZip.Text = getDetails.Tables[0].Rows[0]["NewZipCode"].ToString();
                        lblNewZip.ForeColor = System.Drawing.Color.Red;
                        lblNewZip.Font.Bold = true;
                    }

                    if (getDetails.Tables[0].Rows[0]["NewGroupZipCode"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewGroupZipCode"].ToString() == string.Empty)
                    {
                        lblNewGroupZip.Text = @"No Change";
                        lblNewGroupZip.ForeColor = System.Drawing.Color.Empty;
                        lblNewGroupZip.Font.Bold = false;
                    }
                    else
                    {
                        lblNewGroupZip.Text = getDetails.Tables[0].Rows[0]["NewGroupZipCode"].ToString();
                        lblNewGroupZip.ForeColor = System.Drawing.Color.Red;
                        lblNewGroupZip.Font.Bold = true;
                    }

                    lblOldWebSite.Text = getDetails.Tables[0].Rows[0]["OldWebSite"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewWebSite"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewWebSite"].ToString() == string.Empty)
                    {
                        lblNewWebSite.Text = @"No Change";
                        lblNewWebSite.ForeColor = System.Drawing.Color.Empty;
                        lblNewWebSite.Font.Bold = false;
                    }
                    else
                    {
                        lblNewWebSite.Text = getDetails.Tables[0].Rows[0]["NewWebSite"].ToString();
                        lblNewWebSite.ForeColor = System.Drawing.Color.Red;
                        lblNewWebSite.Font.Bold = true;
                    }

                    lblOldPhoneNumber.Text = getDetails.Tables[0].Rows[0]["OldPhoneNumber"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewPhoneNumber"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewPhoneNumber"].ToString() == string.Empty)
                    {
                        lblNewPhoneNumber.Text = @"No Change";
                        lblNewPhoneNumber.ForeColor = System.Drawing.Color.Empty;
                        lblNewPhoneNumber.Font.Bold = false;
                    }
                    else
                    {
                        lblNewPhoneNumber.Text = getDetails.Tables[0].Rows[0]["NewPhoneNumber"].ToString();
                        lblNewPhoneNumber.ForeColor = System.Drawing.Color.Red;
                        lblNewPhoneNumber.Font.Bold = true;
                    }

                    lblOldCity.Text = getDetails.Tables[0].Rows[0]["OldCity"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewCity"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewCity"].ToString() == string.Empty)
                    {
                        lblNewCity.Text = @"No Change";
                        lblNewCity.ForeColor = System.Drawing.Color.Empty;
                        lblNewCity.Font.Bold = false;
                    }
                    else
                    {
                        lblNewCity.Text = getDetails.Tables[0].Rows[0]["NewCity"].ToString();
                        lblNewCity.ForeColor = System.Drawing.Color.Red;
                        lblNewCity.Font.Bold = true;
                    }

                    lblOldEmail.Text = getDetails.Tables[0].Rows[0]["OldEmail"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewEmail"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewEmail"].ToString() == string.Empty)
                    {
                        lblNewEmail.Text = @"No Change";
                        lblNewEmail.ForeColor = System.Drawing.Color.Empty;
                        lblNewEmail.Font.Bold = false;
                    }
                    else
                    {
                        lblNewEmail.Text = getDetails.Tables[0].Rows[0]["NewEmail"].ToString();
                        lblNewEmail.ForeColor = System.Drawing.Color.Red;
                        lblNewEmail.Font.Bold = true;
                    }

                    lblOldCountry.Text = getDetails.Tables[0].Rows[0]["OldCountry"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewCountry"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewCountry"].ToString() == string.Empty)
                    {
                        lblNewCountry.Text = @"No Change";
                        lblNewCountry.ForeColor = System.Drawing.Color.Empty;
                        lblNewCountry.Font.Bold = false;
                    }
                    else
                    {
                        lblNewCountry.Text = getDetails.Tables[0].Rows[0]["NewCountry"].ToString();
                        lblNewCountry.ForeColor = System.Drawing.Color.Red;
                        lblNewCountry.Font.Bold = true;
                    }

                    lblOldSector.Text = getDetails.Tables[0].Rows[0]["OldSector"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewSector"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewSector"].ToString() == string.Empty)
                    {
                        lblNewSector.Text = @"No Change";
                        lblNewSector.ForeColor = System.Drawing.Color.Empty;
                        lblNewSector.Font.Bold = false;
                    }
                    else
                    {
                        lblNewSector.Text = getDetails.Tables[0].Rows[0]["NewSector"].ToString();
                        lblNewSector.ForeColor = System.Drawing.Color.Red;
                        lblNewSector.Font.Bold = true;
                    }

                    lblOldCustomerType.Text = getDetails.Tables[0].Rows[0]["OldCustomerType"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewCustomerType"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewCustomerType"].ToString() == string.Empty)
                    {
                        lblNewCustomerType.Text = @"No Change";
                        lblNewCustomerType.ForeColor = System.Drawing.Color.Empty;
                        lblNewCustomerType.Font.Bold = false;
                    }
                    else
                    {
                        lblNewCustomerType.Text = getDetails.Tables[0].Rows[0]["NewCustomerType"].ToString();
                        lblNewCustomerType.ForeColor = System.Drawing.Color.Red;
                        lblNewCustomerType.Font.Bold = true;
                    }

                    lblOldFax.Text = getDetails.Tables[0].Rows[0]["OldFax"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewFax"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewFax"].ToString() == string.Empty)
                    {
                        lblNewFax.Text = @"No Change";
                        lblNewFax.ForeColor = System.Drawing.Color.Empty;
                        lblNewFax.Font.Bold = false;
                    }
                    else
                    {
                        lblNewFax.Text = getDetails.Tables[0].Rows[0]["NewFax"].ToString();
                        lblNewFax.ForeColor = System.Drawing.Color.Red;
                        lblNewFax.Font.Bold = true;
                    }

                    lblOldContactPerson.Text = getDetails.Tables[0].Rows[0]["OldClientContactPerson"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewClientContactPerson"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewClientContactPerson"].ToString() == string.Empty)
                    {
                        lblNewContactPerson.Text = @"No Change";
                        lblNewContactPerson.ForeColor = System.Drawing.Color.Empty;
                        lblNewContactPerson.Font.Bold = false;
                    }
                    else
                    {
                        lblNewContactPerson.Text = getDetails.Tables[0].Rows[0]["NewClientContactPerson"].ToString();
                        lblNewContactPerson.ForeColor = System.Drawing.Color.Red;
                        lblNewContactPerson.Font.Bold = true;
                    }

                    lblOldCustomerPhone.Text = getDetails.Tables[0].Rows[0]["OldClientContactPersonPhoneNumber"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewClientContactPersonPhoneNumber"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewClientContactPersonPhoneNumber"].ToString() == string.Empty)
                    {
                        lblNewCustomerPhone.Text = @"No Change";
                        lblNewCustomerPhone.ForeColor = System.Drawing.Color.Empty;
                        lblNewCustomerPhone.Font.Bold = false;
                    }
                    else
                    {
                        lblNewCustomerPhone.Text = getDetails.Tables[0].Rows[0]["NewClientContactPersonPhoneNumber"].ToString();
                        lblNewCustomerPhone.ForeColor = System.Drawing.Color.Red;
                        lblNewCustomerPhone.Font.Bold = true;
                    }

                    lblOldDesignation.Text = getDetails.Tables[0].Rows[0]["OldClientContactPersonDesignation"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewClientContactPersonDesignation"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewClientContactPersonDesignation"].ToString() == string.Empty)
                    {
                        lblNewDesignation.Text = @"No Change";
                        lblNewDesignation.ForeColor = System.Drawing.Color.Empty;
                        lblNewDesignation.Font.Bold = false;
                    }
                    else
                    {
                        lblNewDesignation.Text = getDetails.Tables[0].Rows[0]["NewClientContactPersonDesignation"].ToString();
                        lblNewDesignation.ForeColor = System.Drawing.Color.Red;
                        lblNewDesignation.Font.Bold = true;
                    }
                }
                else if (requestType.Value == "CustomerConstraintType" || requestType.Value == "Language" || requestType.Value == "Qualification" || requestType.Value == "SaleConstraint" || requestType.Value == "Training")
                {
                    lblOldConstraint.Text = getDetails.Tables[0].Rows[0]["OldConstraint"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewConstraint"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewConstraint"].ToString() == string.Empty)
                    {
                        lblNewConstraint.Text = @"No Change";
                        lblNewConstraint.ForeColor = System.Drawing.Color.Empty;
                        lblNewConstraint.Font.Bold = false;
                    }
                    else
                    {
                        lblNewConstraint.Text = getDetails.Tables[0].Rows[0]["NewConstraint"].ToString();
                        lblNewConstraint.ForeColor = System.Drawing.Color.Red;
                        lblNewConstraint.Font.Bold = true;
                    }

                    if (requestType.Value == "CustomerConstraintType" || requestType.Value == "SaleConstraint")
                    {
                        lblOperatorHeading.Visible = true;
                        lblValueHeading.Visible = true;
                        lblOldOperator.Visible = true;
                        lblNewOperator.Visible = true;
                        lblOldValue.Visible = true;
                        lblNewValue.Visible = true;

                        lblOldOperator.Text = string.Empty;
                        lblNewOperator.Text = string.Empty;
                        lblOldValue.Text = string.Empty;
                        lblNewValue.Text = string.Empty;

                        lblOldOperator.Text = getDetails.Tables[0].Rows[0]["OldOperator"].ToString();
                        if (getDetails.Tables[0].Rows[0]["NewOperator"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewOperator"].ToString() == string.Empty)
                        {
                            lblNewOperator.Text = @"No Change";
                            lblNewOperator.ForeColor = System.Drawing.Color.Empty;
                            lblNewOperator.Font.Bold = false;
                        }
                        else
                        {
                            lblNewOperator.Text = getDetails.Tables[0].Rows[0]["NewOperator"].ToString();
                            lblNewOperator.ForeColor = System.Drawing.Color.Red;
                            lblNewOperator.Font.Bold = true;
                        }

                        lblOldValue.Text = getDetails.Tables[0].Rows[0]["OldValue"].ToString();
                        if (getDetails.Tables[0].Rows[0]["NewValue"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewValue"].ToString() == string.Empty)
                        {
                            lblNewValue.Text = @"No Change";
                            lblNewValue.ForeColor = System.Drawing.Color.Empty;
                            lblNewValue.Font.Bold = false;
                        }
                        else
                        {
                            lblNewValue.Text = getDetails.Tables[0].Rows[0]["NewValue"].ToString();
                            lblNewValue.ForeColor = System.Drawing.Color.Red;
                            lblNewValue.Font.Bold = true;
                        }
                    }
                    else
                    {
                        lblOperatorHeading.Visible = false;
                        lblValueHeading.Visible = false;
                        lblOldOperator.Visible = false;
                        lblNewOperator.Visible = false;
                        lblOldValue.Visible = false;
                        lblNewValue.Visible = false;
                    }

                    lblOldRigidityLevel.Text = getDetails.Tables[0].Rows[0]["OldRigidityLevel"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewRigidityLevel"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewRigidityLevel"].ToString() == string.Empty)
                    {
                        lblNewRigidityLevel.Text = @"No Change";
                        lblNewRigidityLevel.ForeColor = System.Drawing.Color.Empty;
                        lblNewRigidityLevel.Font.Bold = false;
                    }
                    else
                    {
                        lblNewRigidityLevel.Text = getDetails.Tables[0].Rows[0]["NewRigidityLevel"].ToString();
                        lblNewRigidityLevel.ForeColor = System.Drawing.Color.Red;
                        lblNewRigidityLevel.Font.Bold = true;
                    }
                }
                else if (requestType.Value == "Assignment")
                {
                    lblOldAssignmentName.Text = getDetails.Tables[0].Rows[0]["OldAsmtName"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewAsmtName"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewAsmtName"].ToString() == string.Empty)
                    {
                        lblNewAssignmentName.Text = @"No Change";
                        lblNewAssignmentName.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentName.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentName.Text = getDetails.Tables[0].Rows[0]["NewAsmtName"].ToString();
                        lblNewAssignmentName.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentName.Font.Bold = true;
                    }

                    lblOldAssignmentAddress.Text = getDetails.Tables[0].Rows[0]["OldAsmtName"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewAsmtAddress"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewAsmtAddress"].ToString() == string.Empty)
                    {
                        lblNewAssignmentAddress.Text = @"No Change";
                        lblNewAssignmentAddress.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentAddress.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentAddress.Text = getDetails.Tables[0].Rows[0]["NewAsmtAddress"].ToString();
                        lblNewAssignmentAddress.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentAddress.Font.Bold = true;
                    }

                    lblOldAssignmentCity.Text = getDetails.Tables[0].Rows[0]["OldCity"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewCity"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewCity"].ToString() == string.Empty)
                    {
                        lblNewAssignmentCity.Text = @"No Change";
                        lblNewAssignmentCity.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentCity.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentCity.Text = getDetails.Tables[0].Rows[0]["NewCity"].ToString();
                        lblNewAssignmentCity.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentCity.Font.Bold = true;
                    }

                    lblOldAssignmentZip.Text = getDetails.Tables[0].Rows[0]["OldZip"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewZip"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewZip"].ToString() == string.Empty)
                    {
                        lblNewAssignmentZip.Text = @"No Change";
                        lblNewAssignmentZip.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentZip.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentZip.Text = getDetails.Tables[0].Rows[0]["NewZip"].ToString();
                        lblNewAssignmentZip.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentZip.Font.Bold = true;
                    }

                    lblOldAssignmentGroupZip.Text = getDetails.Tables[0].Rows[0]["OldGroupZipCode"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewGroupZipCode"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewGroupZipCode"].ToString() == string.Empty)
                    {
                        lblNewAssignmentGroupZip.Text = @"No Change";
                        lblNewAssignmentGroupZip.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentGroupZip.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentGroupZip.Text = getDetails.Tables[0].Rows[0]["NewGroupZipCode"].ToString();
                        lblNewAssignmentGroupZip.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentGroupZip.Font.Bold = true;
                    }

                    lblOldAssignmentFax.Text = getDetails.Tables[0].Rows[0]["OldFax"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewFax"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewFax"].ToString() == string.Empty)
                    {
                        lblNewAssignmentFax.Text = @"No Change";
                        lblNewAssignmentFax.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentFax.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentFax.Text = getDetails.Tables[0].Rows[0]["NewFax"].ToString();
                        lblNewAssignmentFax.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentFax.Font.Bold = true;
                    }

                    lblOldAssignmentPhoneNumber.Text = getDetails.Tables[0].Rows[0]["OldPhoneNumber"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewPhoneNumber"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewPhoneNumber"].ToString() == string.Empty)
                    {
                        lblNewAssignmentPhoneNumber.Text = @"No Change";
                        lblNewAssignmentPhoneNumber.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentPhoneNumber.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentPhoneNumber.Text = getDetails.Tables[0].Rows[0]["NewPhoneNumber"].ToString();
                        lblNewAssignmentPhoneNumber.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentPhoneNumber.Font.Bold = true;
                    }

                    lblOldAssignmentEmail.Text = getDetails.Tables[0].Rows[0]["OldEmail"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewEmail"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewEmail"].ToString() == string.Empty)
                    {
                        lblNewAssignmentEmail.Text = @"No Change";
                        lblNewAssignmentEmail.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentEmail.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentEmail.Text = getDetails.Tables[0].Rows[0]["NewEmail"].ToString();
                        lblNewAssignmentEmail.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentEmail.Font.Bold = true;
                    }

                    lblOldAssignmentCountry.Text = getDetails.Tables[0].Rows[0]["OldCountry"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewCountry"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewCountry"].ToString() == string.Empty)
                    {
                        lblNewAssignmentCountry.Text = @"No Change";
                        lblNewAssignmentCountry.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentCountry.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentCountry.Text = getDetails.Tables[0].Rows[0]["NewCountry"].ToString();
                        lblNewAssignmentCountry.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentCountry.Font.Bold = true;
                    }

                    lblOldAssignmentArea.Text = getDetails.Tables[0].Rows[0]["OldArea"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewArea"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewArea"].ToString() == string.Empty)
                    {
                        lblNewAssignmentArea.Text = @"No Change";
                        lblNewAssignmentArea.ForeColor = System.Drawing.Color.Empty;
                        lblNewAssignmentArea.Font.Bold = false;
                    }
                    else
                    {
                        lblNewAssignmentArea.Text = getDetails.Tables[0].Rows[0]["NewArea"].ToString();
                        lblNewAssignmentArea.ForeColor = System.Drawing.Color.Red;
                        lblNewAssignmentArea.Font.Bold = true;
                    }
                }
                else if (requestType.Value == "Deployment")
                {
                    lblOldWeekNo.Text = getDetails.Tables[0].Rows[0]["OldWeek"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewWeek"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewWeek"].ToString() == string.Empty)
                    {
                        lblNewWeekNo.Text = @"No Change";
                        lblNewWeekNo.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewWeekNo.Text = getDetails.Tables[0].Rows[0]["NewWeek"].ToString();
                        lblNewWeekNo.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldShift.Text = getDetails.Tables[0].Rows[0]["OldShiftCode"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewShiftCode"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewShiftCode"].ToString() == string.Empty)
                    {
                        lblNewShift.Text = @"No Change";
                        lblNewShift.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewShift.Text = getDetails.Tables[0].Rows[0]["NewShiftCode"].ToString();
                        lblNewShift.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldWefDate.Text = string.Format("{0:dd-MMM-yyyy}", getDetails.Tables[0].Rows[0]["OldWefDate"]);
                    if (getDetails.Tables[0].Rows[0]["NewWefDate"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewWefDate"].ToString() == string.Empty)
                    {
                        lblNewWefDate.Text = @"No Change";
                        lblNewWefDate.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewWefDate.Text = string.Format("{0:dd-MMM-yyyy}", getDetails.Tables[0].Rows[0]["NewWefDate"]);
                        lblNewWefDate.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldSundayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["OldSunNoOfPersons"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewSunNoOfPersons"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewSunNoOfPersons"].ToString() == string.Empty)
                    {
                        lblNewSundayNoOfPerson.Text = @"No Change";
                        lblNewSundayNoOfPerson.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewSundayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["NewSunNoOfPersons"].ToString();
                        lblNewSundayNoOfPerson.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldSundayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldSunTimeFrom"]);
                    if (getDetails.Tables[0].Rows[0]["NewSunTimeFrom"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewSunTimeFrom"].ToString() == string.Empty)
                    {
                        lblNewSundayTimeFrom.Text = @"No Change";
                        lblNewSundayTimeFrom.ForeColor = System.Drawing.Color.Empty;
                        lblNewSundayTimeFrom.Font.Size = FontUnit.Smaller;
                    }
                    else
                    {
                        lblNewSundayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewSunTimeFrom"]);
                        lblNewSundayTimeFrom.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldSundayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldSunTimeTo"]);
                    if (getDetails.Tables[0].Rows[0]["NewSunTimeTo"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewSunTimeTo"].ToString() == string.Empty)
                    {
                        lblNewSundayTimeTo.Text = @"No Change";
                        lblNewSundayTimeTo.Font.Size = FontUnit.Smaller;
                        lblNewSundayTimeTo.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewSundayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewSunTimeTo"]);
                        lblNewSundayTimeTo.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldMondayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["OldMonNoOfPersons"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewMonNoOfPersons"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewMonNoOfPersons"].ToString() == string.Empty)
                    {
                        lblNewMondayNoOfPerson.Text = @"No Change";
                        lblNewMondayNoOfPerson.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewMondayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["NewMonNoOfPersons"].ToString();
                        lblNewMondayNoOfPerson.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldMondayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldMonTimeFrom"]);
                    if (getDetails.Tables[0].Rows[0]["NewMonTimeFrom"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewMonTimeFrom"].ToString() == string.Empty)
                    {
                        lblNewMondayTimeFrom.Text = @"No Change";
                        lblNewMondayTimeFrom.Font.Size = FontUnit.Smaller;
                        lblNewMondayTimeFrom.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewMondayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewMonTimeFrom"]);
                        lblNewMondayTimeFrom.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldMondayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldMonTimeTo"]);
                    if (getDetails.Tables[0].Rows[0]["NewMonTimeTo"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewMonTimeTo"].ToString() == string.Empty)
                    {
                        lblNewMondayTimeTo.Text = @"No Change";
                        lblNewMondayTimeTo.Font.Size = FontUnit.Smaller;
                        lblNewMondayTimeTo.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewMondayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewMonTimeTo"]);
                        lblNewMondayTimeTo.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldTuesdayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["OldTueNoOfPersons"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewTueNoOfPersons"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewTueNoOfPersons"].ToString() == string.Empty)
                    {
                        lblNewTuesdayNoOfPerson.Text = @"No Change";
                        lblNewTuesdayNoOfPerson.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewTuesdayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["NewTueNoOfPersons"].ToString();
                        lblNewTuesdayNoOfPerson.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldTuesdayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldTueTimeFrom"]);
                    if (getDetails.Tables[0].Rows[0]["NewTueTimeFrom"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewTueTimeFrom"].ToString() == string.Empty)
                    {
                        lblNewTuesdayTimeFrom.Text = @"No Change";
                        lblNewTuesdayTimeFrom.Font.Size = FontUnit.Smaller;
                        lblNewTuesdayTimeFrom.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewTuesdayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewTueTimeFrom"]);
                        lblNewTuesdayTimeFrom.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldTuesdayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldTueTimeTo"]);
                    if (getDetails.Tables[0].Rows[0]["NewTueTimeTo"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewTueTimeTo"].ToString() == string.Empty)
                    {
                        lblNewTuesdayTimeTo.Text = @"No Change";
                        lblNewTuesdayTimeTo.Font.Size = FontUnit.Smaller;
                        lblNewTuesdayTimeTo.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewTuesdayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewTueTimeTo"]);
                        lblNewTuesdayTimeTo.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldWednesdayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["OldWedNoOfPersons"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewWedNoOfPersons"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewWedNoOfPersons"].ToString() == string.Empty)
                    {
                        lblNewWednesdayNoOfPerson.Text = @"No Change";
                        lblNewWednesdayNoOfPerson.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewWednesdayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["NewWedNoOfPersons"].ToString();
                        lblNewWednesdayNoOfPerson.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldWednesdayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldWedTimeFrom"]);
                    if (getDetails.Tables[0].Rows[0]["NewWedTimeFrom"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewWedTimeFrom"].ToString() == string.Empty)
                    {
                        lblNewWednesdayTimeFrom.Text = @"No Change";
                        lblNewWednesdayTimeFrom.Font.Size = FontUnit.Smaller;
                        lblNewWednesdayTimeFrom.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewWednesdayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewWedTimeFrom"]);
                        lblNewWednesdayTimeFrom.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldWednesdayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldWedTimeTo"]);
                    if (getDetails.Tables[0].Rows[0]["NewWedTimeTo"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewWedTimeTo"].ToString() == string.Empty)
                    {
                        lblNewWednesdayTimeTo.Text = @"No Change";
                        lblNewWednesdayTimeTo.Font.Size = FontUnit.Smaller;
                        lblNewWednesdayTimeTo.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewWednesdayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewWedTimeTo"]);
                        lblNewWednesdayTimeTo.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldThursdayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["OldThuNoOfPersons"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewThuNoOfPersons"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewThuNoOfPersons"].ToString() == string.Empty)
                    {
                        lblNewThursdayNoOfPerson.Text = @"No Change";
                        lblNewThursdayNoOfPerson.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewThursdayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["NewThuNoOfPersons"].ToString();
                        lblNewThursdayNoOfPerson.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldThursdayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldThuTimeFrom"]);
                    if (getDetails.Tables[0].Rows[0]["NewThuTimeFrom"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewThuTimeFrom"].ToString() == string.Empty)
                    {
                        lblNewThursdayTimeFrom.Text = @"No Change";
                        lblNewThursdayTimeFrom.Font.Size = FontUnit.Smaller;
                        lblNewThursdayTimeFrom.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewThursdayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewThuTimeFrom"]);
                        lblNewThursdayTimeFrom.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldThursdayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldThuTimeTo"]);
                    if (getDetails.Tables[0].Rows[0]["NewThuTimeTo"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewThuTimeTo"].ToString() == string.Empty)
                    {
                        lblNewThursdayTimeTo.Text = @"No Change";
                        lblNewThursdayTimeTo.Font.Size = FontUnit.Smaller;
                        lblNewThursdayTimeTo.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewThursdayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewThuTimeTo"]);
                        lblNewThursdayTimeTo.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldFridayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["OldFriNoOfPersons"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewFriNoOfPersons"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewFriNoOfPersons"].ToString() == string.Empty)
                    {
                        lblNewFridayNoOfPerson.Text = @"No Change";
                        lblNewFridayNoOfPerson.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewFridayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["NewFriNoOfPersons"].ToString();
                        lblNewFridayNoOfPerson.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldFridayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldFriTimeFrom"]);
                    if (getDetails.Tables[0].Rows[0]["NewFriTimeFrom"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewFriTimeFrom"].ToString() == string.Empty)
                    {
                        lblNewFridayTimeFrom.Text = @"No Change";
                        lblNewFridayTimeFrom.Font.Size = FontUnit.Smaller;
                        lblNewFridayTimeFrom.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewFridayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewFriTimeFrom"]);
                        lblNewFridayTimeFrom.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldFridayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldFriTimeTo"]);
                    if (getDetails.Tables[0].Rows[0]["NewFriTimeTo"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewFriTimeTo"].ToString() == string.Empty)
                    {
                        lblNewFridayTimeTo.Text = @"No Change";
                        lblNewFridayTimeTo.Font.Size = FontUnit.Smaller;
                        lblNewFridayTimeTo.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewFridayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewFriTimeTo"]);
                        lblNewFridayTimeTo.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldSaturdayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["OldSatNoOfPersons"].ToString();
                    if (getDetails.Tables[0].Rows[0]["NewSatNoOfPersons"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewSatNoOfPersons"].ToString() == string.Empty)
                    {
                        lblNewSaturdayNoOfPerson.Text = @"No Change";
                        lblNewSaturdayNoOfPerson.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewSaturdayNoOfPerson.Text = getDetails.Tables[0].Rows[0]["NewSatNoOfPersons"].ToString();
                        lblNewSaturdayNoOfPerson.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldSaturdayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldSatTimeFrom"]);
                    if (getDetails.Tables[0].Rows[0]["NewSatTimeFrom"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewSatTimeFrom"].ToString() == string.Empty)
                    {
                        lblNewSaturdayTimeFrom.Text = @"No Change";
                        lblNewSaturdayTimeFrom.Font.Size = FontUnit.Smaller;
                        lblNewSaturdayTimeFrom.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewSaturdayTimeFrom.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewSatTimeFrom"]);
                        lblNewSaturdayTimeFrom.ForeColor = System.Drawing.Color.Red;
                    }

                    lblOldSaturdayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["OldSatTimeTo"]);
                    if (getDetails.Tables[0].Rows[0]["NewSatTimeTo"].ToString() == "NA" || getDetails.Tables[0].Rows[0]["NewSatTimeTo"].ToString() == string.Empty)
                    {
                        lblNewSaturdayTimeTo.Text = @"No Change";
                        lblNewSaturdayTimeTo.Font.Size = FontUnit.Smaller;
                        lblNewSaturdayTimeTo.ForeColor = System.Drawing.Color.Empty;
                    }
                    else
                    {
                        lblNewSaturdayTimeTo.Text = string.Format("{0:HH:mm}", getDetails.Tables[0].Rows[0]["NewSatTimeTo"]);
                        lblNewSaturdayTimeTo.ForeColor = System.Drawing.Color.Red;
                    }
                }

                lblComment.Text = getDetails.Tables[0].Rows[0]["Comment"].ToString();
            }
        }
    }
}