<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationHeadCostingDetail.aspx.cs" Inherits="Sales_QuotationHeadCostingDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <h3>
            <asp:Label runat="server" ID="lblHeader" Style="color: #2E6293; font-size: x-large;"></asp:Label>
        </h3>
        <div style="width: 50%;">
                        <table width="100%" cellspacing="0px" cellpadding="0px" style="border: solid 1px;">
                            <tr style="background-color: gray; color: white; height: 50px">
                                <td style="text-align: left; width: 400px">
                                    <asp:Label ID="lblCompanyCode" runat="server" Text="<%$ Resources:Resource,Description %>"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:Label ID="Label11" runat="server" Text="<%$ Resources:Resource,Percentage %>"></asp:Label>
                                </td>
                                <td style="text-align: right; width: 200px">
                                    <asp:Label ID="lblHeading" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr style="background-color: #585655; color: white; height: 30px">
                                <td style="text-align: left; width: 400px">
                                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource,DutyDays %>"></asp:Label>
                                </td>
                                <td style="text-align: left; width: 200px"></td>
                                <td style="text-align: right; width: 200px">
                                    <asp:Label ID="lblDutyDays" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
        <div style="width: 50%;">
            <asp:Repeater ID="rptCosting" runat="server" OnItemDataBound="rptCosting_ItemDataBound">
                <HeaderTemplate>
                     </HeaderTemplate>
                <ItemTemplate>
                    <div id="div1" runat="server">
                        <table width="100%" cellspacing="0px" cellpadding="0px" style="border: solid 1px;">
                            <tr>
                                <asp:HiddenField ID="hfHeadType" runat="server" Value='<%# Eval("HeadCodeType") %>' />
                                <td style="text-align: left; width: 400px">
                                    <asp:Label ID="lblHeadcode" runat="server" Text='<%# Eval("HeadCodeDesc") %>' />
                                </td>
                                <td style="text-align: left; width: 200px">
                                    <asp:Label ID="lblValue" runat="server" Text='<%# Eval("HeadCodeValue") %>' />
                                </td>
                                <td style="text-align: right; width: 200px">
                                    <asp:Label ID="lblHeadCodeValue" runat="server" Text='<%# Eval("HeadCodeCalculatedValue") %>' />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
  
    <br />
    <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource,Back %>" CssClass="cssButton" OnClick="btnBack_Click"  />
          </center>
    <asp:HiddenField ID="hfComapnyCode" runat="server" />
    <asp:HiddenField ID="hfDesignation" runat="server" />
    <asp:HiddenField ID="hfState" runat="server" />
      <asp:HiddenField ID="hfGradeCode" runat="server" />
</asp:Content>

