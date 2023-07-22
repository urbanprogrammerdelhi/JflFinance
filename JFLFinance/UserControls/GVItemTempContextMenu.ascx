<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GVItemTempContextMenu.ascx.cs" Inherits="UserControls_GVItemTempContextMenu" %>
<div id="divGVItemTemplate" class="section" style="display:none; position:absolute;">
    <table style="border:0px;">
        <tr>
            <td>
                <asp:ImageButton ID="ImgbtnDelete" runat="server" CssClass="cssImgButton" CommandName="Delete" ToolTip="<%$ Resources:Resource, Delete %>" ImageUrl="../Images/Delete.gif" />
            </td>
            <td>
                <asp:LinkButton runat="server" ID="lnkbtnDelete" CssClass="csslnkButton" Text="<%$ Resources:Resource, Delete %>" CommandName="Delete"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImgbtnEdit" runat="server" CssClass="cssImgButton" CommandName="Edit" ToolTip="<%$ Resources:Resource, Edit %>" ImageUrl="../Images/Edit.gif" />
            </td>
            <td>
                <asp:LinkButton runat="server" ID="lnkbtnEdit" CssClass="csslnkButton" Text="<%$ Resources:Resource, Edit %>" CommandName="Edit"></asp:LinkButton>
            </td>
        </tr>
    </table>
</div>