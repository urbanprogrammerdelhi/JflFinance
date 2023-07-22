<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DeviceUserSiteRights.aspx.cs" Inherits="UserManagement_DeviceUserSiteRights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="divheader" >
        <asp:Label ID="lblUserIDhdr" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserID %>"></asp:Label>:&nbsp;
        <asp:Label Style="text-align: left;" CssClass="cssLabelHeader" Width="150px" ID="lblUserID" runat="server" Text="Administrator"></asp:Label>&nbsp;
        <asp:Label ID="lblUserNamehdr" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, UserName %>"></asp:Label>:&nbsp;
        <asp:Label Style="text-align: left;" CssClass="cssLabelHeader" Width="150px" ID="lblUserName" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:Resource, Save %>" CssClass="cssButton" OnClick="btnSave_Click" />
    </div>

    <dx:ASPxTreeView ID="tvSiteRights" runat="server" AllowSelectNode="true" AllowCheckNodes="true" EnableHotTrack="true" ShowExpandButtons="true" CheckNodesRecursive="true">

    </dx:ASPxTreeView>

    <asp:Label ID="lblErrorMsg" CssClass="csslblErrMsg" Text="" EnableViewState="false" runat="server"></asp:Label>
</asp:Content>

