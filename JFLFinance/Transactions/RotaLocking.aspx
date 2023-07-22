<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="RotaLocking.aspx.cs" Inherits="Transactions_RotaLocking" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="3" cellspacing="0">
        <tr>
            <td align="center">
                <div style="width: 950px;">
                    <div class="squarebox">
                        <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                            <div style="float: left; width: 670px;">
                                <tt style="text-align: center;">
                                    <asp:Label ID="Label5" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource, RotaLock %>"></asp:Label></tt></div>
                        </div>
                        <div class="squareboxcontent">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 950px">
                                <tr>
                                    <td align="right" style="width: 350px">
                                        <asp:Label ID="lblHrLocation" runat="server" Text="<%$Resources:Resource,HrLocation %>"
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 600px">
                                        <asp:DropDownList ID="ddlDivision" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                            Width="300px" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblBranch" runat="server" Text="<%$Resources:Resource,Branch %>" CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlBranch" AutoPostBack="true" runat="server" CssClass="cssDropDown"
                                            OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:Resource,ClientName %> "
                                            CssClass="cssLable"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="cssDropDown" AutoPostBack="False"
                                            Width="350px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnProceed" runat="server" OnClick="btnProceed_Click" CssClass="cssButton"
                                            Text="<%$ Resources:Resource, Proceed %>" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Panel ID="panel1" runat="server">
                                                    <asp:GridView ID="gvRotaLocking" runat="server" Width="950" CssClass="GridViewStyle"
                                                        ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" CellPadding="0"
                                                        PageSize="10" OnPageIndexChanging="gvRotaLocking_PageIndexChanging" OnRowCommand="gvRotaLocking_RowCommand"
                                                        GridLines="None" AutoGenerateColumns="False">
                                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                                        <RowStyle CssClass="GridViewRowStyle" />
                                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                        <PagerStyle CssClass="GridViewPagerStyle" />
                                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="30" HeaderStyle-Width="30" FooterStyle-Width="30">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrgvRotaLockingSno" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvRotaLockingSno" CssClass="cssLable" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="200" HeaderStyle-Width="200" FooterStyle-Width="200">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrgvRotaLockingLocationDesc" CssClass="cssLabelHeader" runat="server"
                                                                        Text="<%$ Resources:Resource,LocationDesc %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvRotaLockingLocationDesc" CssClass="cssLable" runat="server" Text='<%# Eval("LocationDesc").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterStyle Width="200px" />
                                                                <HeaderStyle Width="200px" />
                                                                <ItemStyle Width="200px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="100" HeaderStyle-Width="100" FooterStyle-Width="100">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrgvRotaLockingAsmtCode" CssClass="cssLabelHeader" runat="server"
                                                                        Text="<%$ Resources:Resource,AsmtCode %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvRotaLockingAsmtCode" CssClass="cssLable" runat="server" Text='<%# Eval("AsmtCode").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="80" HeaderStyle-Width="80" FooterStyle-Width="80">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrgvRotaLockingStatus" CssClass="cssLabelHeader" runat="server"
                                                                        Text="<%$ Resources:Resource,Status %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvRotaLockingStatus" CssClass="cssLable" runat="server" Text='<%# Eval("LockingStatus").ToString()%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="130" HeaderStyle-Width="130" FooterStyle-Width="130">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrgvLockingRotaLockingFDate" CssClass="cssLabelHeader" runat="server"
                                                                        Text="<%$ Resources:Resource,FromDate %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvRotaLockingLockingFromDate" CssClass="cssLable" runat="server"
                                                                        Text='<%# string.Format("{0:dd-MMM-yyyy}",Eval("LockingFromDate"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox CssClass="csstxtbox" Width="90" Text="" ID="txtFromDate" runat="server"
                                                                        AutoPostBack="true"></asp:TextBox>
                                                                    <asp:HyperLink ID="ImgFromDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtFromDate" PopupButtonID="ImgFromDate">
                                                                    </AjaxToolKit:CalendarExtender>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="130" HeaderStyle-Width="130" FooterStyle-Width="130">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrgvLockingRotaLockingDate" CssClass="cssLabelHeader" runat="server"
                                                                        Text="<%$ Resources:Resource,ToDate %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvRotaLockingLockingUptoDate" CssClass="cssLable" runat="server"
                                                                        Text='<%# string.Format("{0:dd-MMM-yyyy}",Eval("LockingToDate"))%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:TextBox CssClass="csstxtbox" Width="90" Text="" ID="txtToDate" runat="server"
                                                                        AutoPostBack="true"></asp:TextBox>
                                                                    <asp:HyperLink ID="ImgToDate" Style="vertical-align: middle;" runat="server" ImageUrl="~/Images/pdate.gif"></asp:HyperLink>
                                                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                                                        TargetControlID="txtToDate" PopupButtonID="ImgToDate">
                                                                    </AjaxToolKit:CalendarExtender>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-Width="10">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrgvLockingSelect" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Select %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="LockingAutoId" runat="server" Value='<%# Eval("RotaLockAutoId").ToString()%>' />
                                                                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged" />
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHdrgvLockingAction" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Action %>"></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblgvRotaLockingLockingAction" CssClass="cssLable" runat="server"
                                                                        Text=''></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Button ID="btnLock" CommandName="LockRota" runat="server" CssClass="cssButton"
                                                                        Text="<%$ Resources:Resource, Lock %>" />
                                                                    <asp:Button ID="btnUnLock" CommandName="UnLockRota" runat="server" CssClass="cssButton"
                                                                        Text="<%$ Resources:Resource, unLockRota %>" />
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                     <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </Ajax:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                       
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
