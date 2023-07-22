<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterHeader.master" AutoEventWireup="true"
    CodeFile="MainSelection.aspx.cs" Inherits="MainSelection" Title="IFM 360" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
    <ContentTemplate>
        <%--<p class="pagetitler">Select Branch</p>--%>
            <div class="mainselectionwrap">
            <div class="sidebox fl">
                <asp:Label ID="lblCompany" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, Company %>"></asp:Label>
                <asp:Label ID="lblHrLocation" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, HrLocation %>"></asp:Label>
                <asp:Label ID="lblLocation" runat="server" CssClass="cssLable" Text="<%$ Resources:Resource, Location %>"></asp:Label>
             </div>
            <div class="roundedwhitebox fl">
                                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="customdropdwon" 
                                        OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlHrLocation" runat="server" CssClass="customdropdwon" 
                                        OnSelectedIndexChanged="ddlHrLocation_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlLocation" runat="server" CssClass="customdropdwon" 
                                        OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
                                    </asp:DropDownList>
            </div>
            <div>
                <asp:Label ID="lblCompanyCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>                                    
                <%--<asp:Label ID="lblvalCompany" runat="server" CssClass="cssLable" Text=""></asp:Label>--%>

                <asp:Label ID="lblHrLocationCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                <%--<asp:Label ID="lblvalHrLocation" runat="server" CssClass="cssLable" Text=""></asp:Label>--%>

                <asp:Label ID="lblLocationCode" runat="server" CssClass="cssLable" Text="" Visible="false"></asp:Label>
                <%--<asp:Label ID="lblvalLocation" runat="server" CssClass="cssLable" Text=""></asp:Label>--%>
            </div>
            </div>
            <br clear="all" />

            <div class="sigin submitwrap"> 
	            <asp:Button ID="btnContinue" runat="server" CssClass="cssLoginButton" OnClick="btnContinue_Click" Text="<%$ Resources:Resource, Continue %>" />
            </div>

            <asp:HiddenField ID="HFUserID" runat="server" />
            <asp:HiddenField ID="HFCountryCode" runat="server" />
            <asp:Label ID="lblErrMsg" runat="server" CssClass="csslblErrMsg" Text=""></asp:Label>
            <asp:Label ID="lblErrMsg1" runat="server" CssClass="csslblErrMsg" Text=""></asp:Label>
    </ContentTemplate>
</Ajax:UpdatePanel>
</asp:Content>
