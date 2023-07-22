<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="EmpsLeaveDetail.aspx.cs" Inherits="Transactions_EmpsLeaveDetail" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td><br>&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="cssDropDown" Width="80" >
                            <asp:ListItem Text="<%$ Resources:Resource,January%>" Value="Jan"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,February%>" Value="Feb"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,March%>" Value="Mar"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,April%>" Value="Apr"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,May%>" Value="May"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,June%>" Value="Jun"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,July%>" Value="Jul"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,August%>" Value="Aug"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,September%>" Value="Sep"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,October%>" Value="Oct"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,November%>" Value="Nov"></asp:ListItem>
                            <asp:ListItem Text="<%$ Resources:Resource,December%>" Value="Dec"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox Width="40px" CssClass="csstxtbox" ID="txtYear" MaxLength="4" runat="server"
                            AutoPostBack="false">
                        </asp:TextBox>
                        &nbsp;
                        <asp:LinkButton ID="btnChangeMonth" runat="server" Text="<%$ Resources:Resource,Ok%>" OnClick="btnChangeMonth_Click" ></asp:LinkButton>
                        &nbsp;
                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
                    </td>
                </tr>
                <tr>
                <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="950px" Height="450px"
                            ScrollBars="Auto" CssClass="ScrollBar">
                            <asp:GridView Width="950" ID="gvEmployeeLeave" CssClass="GridViewStyle" runat="server"
                                ShowFooter="true" ShowHeader="true" Visible="true" AllowPaging="true" PageSize="50"
                                CellPadding="1" GridLines="None" AutoGenerateColumns="False">
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <Columns>
                                    <asp:TemplateField HeaderStyle-Width="20px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblgvhdrSerialNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,SerialNumber%>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="60px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrEmpNo" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,EmployeeNumber%>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmpNo" CssClass="cssLabel" runat="server" Text='<%# Eval("EmployeeNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="85px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrFromDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,FromDate%>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("FromDate"))%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="85px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrToDate" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,ToDate%>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblToDate" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}", Eval("ToDate"))%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="50px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrNoOfLeave" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Leaves%>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNoOfLeave" CssClass="cssLabel" runat="server" Text='<%# Eval("NoOfDays").ToString()%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="50px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrIsHalf" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,IsHalf%>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIshalf" CssClass="cssLabel" runat="server" Text='<%# Eval("IsHalf")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="90px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrApproved" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,ApproveStatus%>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproved" CssClass="cssLabel" runat="server" Text='<%# Eval("Approved")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="150px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdrApprovedBy" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,ApprovedBy%>"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblApprovedBy" CssClass="cssLabel" runat="server" Text='<%# Eval("ApprovedBy")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:Label ID="lblhdr11" CssClass="cssLabelHeader" runat="server" Text=""></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl11" CssClass="cssLabel" runat="server" Text=''></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            
                                
            <asp:HiddenField ID="Hid_FromDate" runat="server" />
            <asp:HiddenField ID="Hid_ToDate" runat="server" />
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>
