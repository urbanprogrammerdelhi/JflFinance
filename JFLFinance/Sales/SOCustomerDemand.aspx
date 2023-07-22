<%@ Page Language="C#"  MasterPageFile="~/MasterPage/MasterSearch.master"  AutoEventWireup="true" CodeFile="SOCustomerDemand.aspx.cs" Inherits="Sales_SOCustomerDemand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="1" cellspacing="0" style="text-align:left;">
        <tr>
            <td align="left">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                    
                    <table>
                    <tr>
            <td align="center">
                <asp:Panel ID="Panel6" BackColor="white" ScrollBars="none" CssClass="ScrollBar" runat="server"
                    Visible="false" Height="400" Width="750" Style="border: 1px; border-style: solid;
                    border-color: Red">
                    
                   <Ajax:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="always">
                        <ContentTemplate>
                                <asp:GridView ID="grdCustomerDemand" PageSize="5" Width="650px" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" CellPadding="1" CssClass="GridViewStyle" OnPageIndexChanging="grdCustomerDemand_PageIndexChanging">
                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                    <RowStyle CssClass="GridViewRowStyle" />
                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                    <PagerStyle CssClass="GridViewPagerStyle" />
                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                    <Columns>
                                           <asp:TemplateField HeaderStyle-Width="100px" FooterStyle-Width="100px" ItemStyle-Width="100px">
                                                        <HeaderTemplate>
                                                            <asp:Label ID="lblgvhdrIsmandatory" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource, Religion %>"></asp:Label>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbIsMandatory" CssClass="cssCheckBox" runat="server" Enabled="false" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsMendatory").ToString())%>' />
                                                            <asp:Label ID="lblgvCustomerDemand" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CustomerDemandID").ToString()%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:CheckBox ID="cbIsMandatory" CssClass="cssCheckBox" runat="server" Checked='<%# bool.Parse(DataBinder.Eval(Container.DataItem, "IsMendatory").ToString())%>' />
                                                            <asp:HiddenField ID="hfReligion" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "CustomerDemandID").ToString()%>' />
                                                            <asp:DropDownList CssClass="cssDropDown" Width="80px" ID="ddlCusomerDemand" runat="server"></asp:DropDownList>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:CheckBox ID="cbIsMandatory" CssClass="cssCheckBox" runat="server"/>
                                                            <asp:DropDownList CssClass="cssDropDown" Width="80px" ID="ddlCusomerDemand" runat="server"></asp:DropDownList>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
                                <asp:Button ID="btnApply" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource ,Apply %>" OnClick="btnApply_Click"
                                    ValidationGroup="TerminateEmployee"/>
                                <asp:Button ID="btnClose" runat="server" CssClass="cssButton" Text="<%$ Resources:Resource ,Close %>" OnClick="btnClose_Click" />
                        </ContentTemplate>
                    </Ajax:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
       </table>
    </ContentTemplate>
    </Ajax:UpdatePanel>
    </td>
    </tr>
    </table>
    </asp:Content>
