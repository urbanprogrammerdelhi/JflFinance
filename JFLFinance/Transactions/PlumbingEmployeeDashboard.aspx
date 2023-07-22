<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PlumbingEmployeeDashboard.aspx.cs" Inherits="Transactions_PlumbingEmployeeDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:GridView Width="100%" ID="gvEmployeeDashboard" runat="server" CssClass="GridViewStyle" CellPadding="1" GridLines="None" AutoGenerateColumns="false"
        OnRowDataBound="gvEmployeeDashboard_RowDataBound">
        <FooterStyle CssClass="GridViewFooterStyle" />
        <RowStyle CssClass="GridViewRowStyle" />
        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
        <PagerStyle CssClass="GridViewPagerStyle" />
        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
        <HeaderStyle CssClass="GridViewHeaderStyle" />
    </asp:GridView>
    <asp:Label ID="lblError" runat="server" CssClass="csslblErrMsg"></asp:Label>
    <style>
        /*.single {
            border-left: 6px solid Silver;
            background-color: lightgrey;
            height: 20px;
            width: 100px;
        }*/
        .outer {
            border-left: 6px solid Green;
            background-color: lightgrey;
            height: 20px;
            width: 100px;
        }

        .box1 {
            border-left: 6px solid Green;
            background-color: lightgrey;
            padding:2px;
            /*height: 100px;*/
            width: 400px;
            position: absolute;
            display: none;
        }

        .outer:hover .box1 {
            display: block;
            cursor: pointer;
        }
    </style>
</asp:Content>

