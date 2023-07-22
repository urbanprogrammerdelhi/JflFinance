<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetScheduling.aspx.cs" Inherits="Transactions_AssetScheduling" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up2" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr>
                    <td align="right" style="min-width: 200px">
                        <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px" OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblhdrClient" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Client %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtClientCode" runat="server" AutoPostBack="True" CssClass="csstxtbox" Width="200px" OnTextChanged="txtClientCode_TextChanged"></asp:TextBox>
                        <asp:Image ID="ImgClientCode_CCH" runat="server" ImageUrl="~/Images/icosearch.gif" />
                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="280px" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblhdrAsmt" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Asmt %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlAsmt" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px" OnSelectedIndexChanged="ddlAsmt_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label1" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, PostDesc %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlPost" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                            Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource, Date %>"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtServiceDate" CssClass="csstxtboxRequired" runat="server"></asp:TextBox>
                        <asp:HyperLink Style="vertical-align: top;" ID="hlServiceDate" runat="server" Height="19px"
                            Width="20px" ImageUrl="../Images/pdate.gif"></asp:HyperLink>
                        <AjaxToolKit:CalendarExtender ID="CEServiceDate" Format="dd-MMM-yyyy" runat="server" TargetControlID="txtServiceDate"
                            PopupButtonID="hlServiceDate" Enabled="True"></AjaxToolKit:CalendarExtender>
                    </td>
                    <td align="center" colspan="2">
                        <asp:Button runat="server" ID="btnProceed" CssClass="cssButton" Width="150px" Text="Proceed" OnClick="btnProceed_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label CssClass="cssLabel" ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
            <asp:GridView Width="100%" ID="gvAssetScheduling" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="20" CellPadding="1" GridLines="None"
                AutoGenerateColumns="False" OnRowCommand="gvAssetScheduling_RowCommand" OnPageIndexChanging="gvAssetScheduling_PageIndexChanging" OnRowDataBound="gvAssetScheduling_RowDataBound">
                <FooterStyle BackColor="#2e6293" Font-Bold="true" ForeColor="black" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle BackColor="#2e6293" ForeColor="white" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblaction" runat="server" CssClass="cssLabelHeader" Text="<%$ Resources:Resource, EditColName %>" ForeColor="White"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgbtnAdd" runat="server" CssClass="cssImgButton" CommandName="Add"
                                ValidationGroup="vgHrFooter" ToolTip="<%$Resources:Resource,Save %>" ImageUrl="../Images/AddNew.gif" />
                            &nbsp;
                                    <asp:ImageButton ID="ImgbtnReset" runat="server" CssClass="cssImgButton" CommandName="Reset"
                                        ToolTip="<%$ Resources:Resource, Reset %>" ImageUrl="../Images/Reset.gif" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="70px" />
                        <ItemStyle Width="70px" />
                        <FooterStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetServiceTypeName %>" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfAssetServiceTypeAutoId" runat="server" Value='<%# Bind("AssetServiceTypeAutoId") %>' />
                            <asp:Label ID="lblAssetServiceTypeName" Width="120px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetServiceTypeName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="120px" />
                        <ItemStyle Width="120px" />
                        <FooterStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:TextBox ID="txtEmployeeNumber" Width="100px" MaxLength="12" CssClass="csstxtbox" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                        <ItemStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>

                   <%-- <asp:TemplateField HeaderText="Roll Over Shift" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                          <asp:CheckBox ID="chkRollOver" CssClass="cssCheckBox" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="70px" />
                        <ItemStyle Width="70px" />
                        <FooterStyle Width="70px" />
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:HiddenField ID="IsChecked" runat="server" Value='<%# Bind("IsChecked") %>' />
                            <asp:TextBox ID="txtEmployeeName" Width="100px" MaxLength="100" CssClass="csstxtbox" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                        <ItemStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,FromTime %>" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:TextBox ID="txtFromTime" Width="75px" CssClass="csstxtbox" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("SchFromTime")) %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="75px" />
                        <ItemStyle Width="75px" />
                        <FooterStyle Width="75px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ToTime %>" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:TextBox ID="txtToTime" Width="75px" CssClass="csstxtbox" runat="server" Text='<%#String.Format("{0:HH:mm}",Eval("SchToTime")) %>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="75px" />
                        <ItemStyle Width="75px" />
                        <FooterStyle Width="75px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCode %>" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfAssetScheduleAutoId" runat="server" Value='<%# Bind("AssetScheduleAutoId") %>' />
                            <asp:HiddenField ID="hfAssetWoNo" runat="server" Value='<%# Bind("AssetWoNo") %>' />
                            <asp:HiddenField ID="hfAssetWoLineNo" runat="server" Value='<%# Bind("AssetWoLineNo") %>' />
                            <asp:HiddenField ID="hfFromTime" runat="server" Value='<%#String.Format("{0:HH:mm}",Eval("FromTime")) %>' />
                            <asp:HiddenField ID="hfToTime" runat="server" Value='<%#String.Format("{0:HH:mm}",Eval("ToTime")) %>' />
                            <asp:HiddenField ID="hfAssetAutoId" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                            <asp:Label ID="lblAssetCode" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                        <ItemStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="lblAssetName" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                        <ItemStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelNo %>" HeaderStyle-ForeColor="White">
                        <ItemTemplate>
                            <asp:Label ID="lblModelNo" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ModelNo") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                        <ItemStyle Width="100px" />
                        <FooterStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNo %>" HeaderStyle-ForeColor="White" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                        <ItemStyle Width="150px" />
                        <FooterStyle Width="150px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </Ajax:UpdatePanel>
</asp:Content>

