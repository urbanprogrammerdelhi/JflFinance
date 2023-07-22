<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="WorkOrderMaster.aspx.cs" Inherits="Sales_CreateOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
      <asp:Panel ID="PanelCreateOrder" Font-Bold="True" ForeColor="Red" runat="server">
        <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
              <tr>
 <td style="text-align: right;">
                    <asp:Label ID="Label4" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SelectUserID %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlUserId" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlUserId_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="rfvddlUserId" ValidationGroup="CreateOrder" ControlToValidate="ddlUserId" InitialValue="Select" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                 <td style="text-align: right;" nowrap="nowrap">
                    <asp:Label ID="Label5" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,UserName %>"></asp:Label>
                </td>
                <td style="text-align: left;" nowrap="nowrap">
                    <asp:TextBox ID="txtUserName" CssClass="csstxtbox"  ValidationGroup="CreateOrder" MaxLength="10" ReadOnly="true"
                        runat="server"></asp:TextBox>
                      </td>
                <td style="text-align: right;">
                    <asp:Label ID="Label6" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,EmailID %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtUserEmail" MaxLength="10" CssClass="csstxtbox" ValidationGroup="CreateOrder" ReadOnly="true"
                        runat="server"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                 <td style="text-align: right;">
                    <asp:Label ID="lblServiceType" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SelectServiceType %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:DropDownList ID="ddlServiceType" runat="server" CssClass="cssDropDown" Width="150px"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblPreferedFromDate" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PreferedFromDate %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                   <asp:TextBox ID="txtPreferedFromDate" CssClass="csstxtbox"  ValidationGroup="CreateOrder"
                        runat="server"></asp:TextBox>  
                      <asp:ImageButton ID="ImageButton3" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtPreferedFromDate" PopupButtonID="ImageButton3" Enabled="True"></AjaxToolKit:CalendarExtender>
                          <asp:RequiredFieldValidator ID="rfvPreferedFromDate" ValidationGroup="CreateOrder" ControlToValidate="txtPreferedFromDate" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblPreferedToDate" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PreferedToDate %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                     <asp:TextBox ID="txtPreferedToDate" CssClass="csstxtbox"  ValidationGroup="CreateOrder"
                        runat="server"></asp:TextBox> 
                      <asp:ImageButton ID="ImageButton4" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtPreferedToDate" PopupButtonID="ImageButton4" Enabled="True"></AjaxToolKit:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvtxtPreferedToDate" ValidationGroup="CreateOrder" ControlToValidate="txtPreferedToDate" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" nowrap="nowrap">
                    <asp:Label ID="lblPreferedFromTime" Width="100px" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PreferedFromTime %>"></asp:Label>
                </td>
                <td style="text-align: left;" nowrap="nowrap">
                    <ajaxToolkit:MaskedEditExtender runat="server"  ID="MEE2"   TargetControlID="txtPreferedFromTime"     Mask="99:99" />
                    <asp:TextBox ID="txtPreferedFromTime" CssClass="csstxtbox"  ValidationGroup="CreateOrder" MaxLength="10"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtPreferedFromTime" ValidationGroup="CreateOrder" ControlToValidate="txtPreferedFromTime" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblPreferedToTime" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PreferedToTime %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                      <ajaxToolkit:MaskedEditExtender runat="server"  ID="MEE1"  TargetControlID="txtPreferedToTime"     Mask="99:99" />
                    <asp:TextBox ID="txtPreferedToTime" MaxLength="10" CssClass="csstxtbox" ValidationGroup="CreateOrder" 
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtPreferedToTime" ValidationGroup="CreateOrder" ControlToValidate="txtPreferedToTime" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblMobile" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Mobile %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtMobile" MaxLength="15" CssClass="csstxtbox" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvtxtMobile" ValidationGroup="CreateOrder" ControlToValidate="txtMobile" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblBuildingNumber" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,BuildingNumber %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtBuildingNumber" MaxLength="100" CssClass="csstxtbox" ValidationGroup="CreateOrder"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtBuildingNumber" ValidationGroup="CreateOrder" ControlToValidate="txtBuildingNumber" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblFloorNumber" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,FloorNumber %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtFloorNumber" MaxLength="100" CssClass="csstxtbox"   runat="server" ValidationGroup="CreateOrder"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvtxtFloorNumber" ValidationGroup="CreateOrder" ControlToValidate="txtFloorNumber" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblLocality" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Locality %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtLocality" MaxLength="100" CssClass="csstxtbox" ValidationGroup="CreateOrder"
                        runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvtxtLocality" ValidationGroup="CreateOrder" ControlToValidate="txtLocality" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblState" CssClass="cssLable" Style="width: 130px;" runat="server"
                      Text="<%$ Resources:Resource,State1 %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                     <asp:DropDownList ID="ddlState" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblDistrict" CssClass="cssLable" Style="width: 100px;" runat="server"
                        Text="<%$ Resources:Resource,District %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                   <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="cssDropDown" Width="150px"></asp:DropDownList>
            </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblCity" CssClass="cssLable" Style="width: 100px;" runat="server"
                        Text="<%$ Resources:Resource,City %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                     <asp:TextBox ID="txtCity" MaxLength="100"  CssClass="csstxtbox" ValidationGroup="CreateOrder"
                        runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvtxtCity" ValidationGroup="CreateOrder" ControlToValidate="txtCity" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Label ID="lblLandmark" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Landmark %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                   <asp:TextBox ID="txtLandmark" MaxLength="100"  CssClass="csstxtbox" ValidationGroup="CreateOrder"
                        runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="rfvtxtLandmark" ValidationGroup="CreateOrder" ControlToValidate="txtLandmark" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblPincode" CssClass="cssLable" Style="width: 100px;" runat="server"
                        Text="<%$ Resources:Resource,Pincode %>"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:TextBox ID="txtPincode" MaxLength="6"  CssClass="csstxtbox" ValidationGroup="CreateOrder"
                        runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfvtxtPincode" ValidationGroup="CreateOrder" ControlToValidate="txtPincode" Display="Dynamic" runat="server" Text="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
          
        </table>
        <asp:Label ID="lblCreateOrder" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
        <div style="margin-left: 450px; margin-top: 25px;">
            <asp:Button ID="btnedit" runat="server" Text="Edit Order" ValidationGroup="CreateOrder" CausesValidation="true" CssClass="cssButton" OnClick="btnedit_Click" Visible="false" />
           <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="cssButton" OnClick="btnReset_Click" Visible="false" />
              <asp:Button ID="btnSubmit" runat="server" Text="Create Order" ValidationGroup="CreateOrder" CausesValidation="true" CssClass="cssButton" OnClick="btnSubmit_Click" Visible="false" />
           <asp:HiddenField ID="HfId" runat="server" />
            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="cssButton" OnClick="btnBack_Click"/>
        </div>
    </asp:Panel>
</asp:Content>

