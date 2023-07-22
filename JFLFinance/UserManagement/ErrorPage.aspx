<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ErrorPage.aspx.cs" Inherits="UserManagement_ErrorPage" Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <br />
    <br />
    <div style="text-align: center; width: 100%;">
        <img id="imgError" src="../Images/Error.jpg" />
        <h1>
            An Error Has Occured
        </h1>
        <%--There is a problem with the page you are trying to reach and it cannot be displayed.--%>
        An unexpected error occured on our website.The web site administrator has been notified.
        <p>
            <asp:Label ID="lblErrorMsg" runat="server" CssClass=" csslblErrMsg"></asp:Label>
        </p>
        <p>
            Please try again later:</p>
        <ul>
            <li>Please contact for more assistance</li>
            <%-- An e-mail has been sent to the site owner to report the problem.--%>
        </ul>
    </div>
</asp:Content>
