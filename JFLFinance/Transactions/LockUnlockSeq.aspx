<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPage.master"
    CodeFile="LockUnlockSeq.aspx.cs" Inherits="Transactions_LockUnlockSeq" Title="<%$ Resources:Resource, AppTitle %>" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 900px;">
                <div class="squarebox">
                    <div class="squareboxgradientcaption" style="height: 15px; cursor: pointer;" ">
                        <div style="float: left; width: 870px;">
                            <tt style="text-align: center;">
                                <asp:Label ID="Label6" CssClass="squareboxgradientcaption" runat="server" Text="<%$ Resources:Resource,LockUnlockSeq %>"></asp:Label></tt>
                        </div>
                    </div>
                    <div class="squareboxcontent">
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="1050px" Height="550px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView Width="950px" ID="gvLockUnlockSeq" PageSize="15" CssClass="GridViewStyle"
                                            runat="server" ShowFooter="False" AllowPaging="True" CellPadding="1" DataKeyNames="PatternSeqAutoID"
                                            AutoGenerateColumns="False" OnPageIndexChanging="gvLockUnlockSeq_PageIndexChanging"
                                            OnRowDataBound="gvLockUnlockSeq_RowDataBound">
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                                    FooterStyle-Width="50px" ItemStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,PatternSequenceCode %>" HeaderStyle-Width="200px"
                                                    FooterStyle-Width="200px" ItemStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQualificationCode" Width="180px" CssClass="cssLable" runat="server"
                                                            Text='<%# Bind("PatternSeqCode") %>'></asp:Label>
                                                        <asp:HiddenField ID="hfPatternSeqAutoID" runat="server" Value='<%# Bind("PatternSeqAutoID") %>' />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ShiftPattern %>" HeaderStyle-Width="600px"
                                                    FooterStyle-Width="600px" ItemStyle-Width="600px">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="ddlPattern" runat="server" CssClass="cssDropDown" Width="100px">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ClientName %>" HeaderStyle-Width="600px"
                                                    FooterStyle-Width="600px" ItemStyle-Width="600px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>' CssClass="cssLabel"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,Assignment %>" HeaderStyle-Width="600px"
                                                    FooterStyle-Width="600px" ItemStyle-Width="600px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAsmtName" runat="server" Text='<%# Bind("AsmtName") %>' CssClass="cssLabel"></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,IsActive %>" HeaderStyle-Width="600px"
                                                    FooterStyle-Width="600px" ItemStyle-Width="600px">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="cbIsActive" runat="server" CssClass="cssCheckBox" Checked='<%# Bind("IsActive") %>'
                                                            OnCheckedChanged="cbIsActive_CheckedChanged" AutoPostBack="true" />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <%-- <script language="javascript" type="text/javascript">

        window.onunload = window.opener.RefreshSequenceDropDown(); // CallParentWindowFunction;

        //        function CallParentWindowFunction() {

        //            window.opener.RefreshSequenceDropDown();
        //            window.close();
        //            return false;

        //        }
    </script>--%>
</asp:Content>
