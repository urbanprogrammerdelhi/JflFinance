<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="RealTimeDuty.aspx.cs" Inherits="MonitorScreen_RealTimeDuty" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td align="right">
                <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true" Width="125px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblhdrClient" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="280" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="right">
                <asp:Label ID="lblhdrAsmt" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Asmt %>"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlAsmt" runat="server" CssClass="cssDropDown" AutoPostBack="false" Width="280">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, FromDate %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFromDate" ValidationGroup="VGView" Width="90px" runat="server"
                    CssClass="csstxtbox"></asp:TextBox>
                <asp:Image ID="imgDate" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="ajxCal" runat="server" TargetControlID="txtFromDate"
                    PopupButtonID="imgDate" Enabled="True" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFromDate"
                    ErrorMessage="*" ValidationGroup="VGView" SetFocusOnError="True" />
            </td>
            <td>
                <asp:Label ID="lblToDate" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, ToDate %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtToDate" ValidationGroup="VGView" Width="90px" runat="server"
                    CssClass="csstxtbox"></asp:TextBox>
                <asp:Image ID="imgDateTo" runat="server" Style="vertical-align: middle;" ImageUrl="~/Images/pdate.gif" />
                <AjaxToolKit:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender7" runat="server"
                    TargetControlID="txtToDate" PopupButtonID="imgDateTo" Enabled="True" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtToDate"
                    ErrorMessage="*" ValidationGroup="VGView" SetFocusOnError="True" />
            </td>
            <td align="left">
                <asp:Button ID="btnView" CssClass="cssButton" OnClick="btnView_Click" runat="server" Text="<%$ Resources:Resource,View %>" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvRealTimeAtt" CssClass="GridViewStyle" runat="server" Width="100%"
        ShowFooter="false" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None" AutoGenerateColumns="False">
        <RowStyle CssClass="GridViewRowStyle" />
        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
        <HeaderStyle CssClass="GridViewHeaderStyle" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" />
                <HeaderStyle Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrClientName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, ClientName %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgvClientName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName").ToString()%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrAsmtName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, AsmtName %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgvAsmtName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "AsmtName").ToString()%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrPostDesc" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, PostDesc %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgvPostDesc" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PostDesc").ToString()%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrEmployeeNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgvEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeNumber").ToString()%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrEmployeeName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgvEmployeeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName").ToString()%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrDutyDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, DutyDate %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgvDutyDate" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DutyDateTime")) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrDutyTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Time %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgvDutyTime" CssClass="cssLable" runat="server" Text='<%# String.Format("{0:HH:mm}",Eval("DutyDateTime")) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblgvhdrStatus" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Status %>"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblgvStatus" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status").ToString()%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
                <HeaderStyle Width="200px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
