<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ShiftWiseEmployeePresent.aspx.cs" Inherits="Transactions_ShiftWiseEmployeePresent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="squareboxgradientcaption" style="height: 20px;">
                <asp:Label ID="Label2" runat="server" Text="<%$Resources:Resource,Dashboard %>"></asp:Label>
            </div>
            <div style="overflow: auto;">
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                                Width="229px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblhdrDutyDate" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,DutyDate  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDutyDate" CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:HyperLink Style="vertical-align: top;" ID="HlimgDutyDate"
                                runat="server" Height="19px" Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                            <AjaxToolKit:CalendarExtender ID="CEDutyDate" Format="dd-MMM-yyyy" runat="server"
                                TargetControlID="txtDutyDate" PopupButtonID="HlimgDutyDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblfixClientName" CssClass="cssLabel" runat="server"
                                Text="<%$ Resources:Resource, Client %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList AutoPostBack="true" CssClass="cssDropDown" Width="380px" ID="ddlClientCode"
                                runat="server" OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label Width="50px" ID="lblAssmtId" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,AsmtId  %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlAsmtId" Width="400px" CssClass="cssDropDown" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="btnView" runat="server" CssClass="cssButton" Text="<%$Resources:Resource,View %>" OnClick="btnView_Click" />
                        </td>
                    </tr>
                </table>
                <asp:GridView Width="100%" ID="gvActual" Style="min-width: 940px;" CssClass="GridViewStyle" runat="server"
                    ShowFooter="true" ShowHeader="true" Visible="true" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnRowDataBound="gvActual_RowDataBound">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
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
                            <FooterStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrActEmployeeNumber" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeNumber %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvActEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActEmployeeNumber").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrActEmployeeName" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, EmployeeName %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvActEmployeeName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActEmployeeName").ToString()%>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblgvhdrActShiftTime" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Time %>"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblgvActShiftTime" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ActShiftTime").ToString()%>'></asp:Label>
                                <asp:HiddenField ID="hfIsOT" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IsOT").ToString()%>' />
                            </ItemTemplate>
                            <FooterStyle Width="200px" />
                            <HeaderStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" Text="" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>

