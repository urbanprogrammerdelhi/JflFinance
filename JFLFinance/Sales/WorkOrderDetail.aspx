<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="WorkOrderDetail.aspx.cs" Inherits="Sales_WorkOrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="squareboxgradientcaption" style="height: 25px; background-color: silver;">
        <asp:Label ID="Label1" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="<%$ Resources:Resource,OrderDetail %>"></asp:Label>
    </div>
    <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px" class="table table-hover">
        <tr>
            <td style="text-align: right; width: 12%;" nowrap="nowrap">
                <asp:Label ID="lblOrderNo1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,OrderNo %>"></asp:Label>
            </td>
            <td style="text-align: left;" nowrap="nowrap">
                <asp:Label ID="lblOrderNo" CssClass="cssLable" runat="server"></asp:Label>
            </td>
            <td style="text-align: right; width: 12%;">
                <asp:Label ID="lblOrderDate1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,OrderDate %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblOrderDate" CssClass="cssLable" runat="server"></asp:Label>
            </td>
            <td style="text-align: right; width: 12%;">
                <asp:Label ID="lblOrderstatus1" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,OrderStatus %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblOrderstatus" CssClass="cssLable" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:Label ID="Label19" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,PreferredDate %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblPreferredDate" CssClass="cssLable" runat="server"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label6" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,PreferredTimeSlot %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblTimeslot" CssClass="cssLable" runat="server"></asp:Label>
            </td>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td style="text-align: right;" nowrap="nowrap">
                <asp:Label ID="Label3" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Service %>"></asp:Label>
            </td>
            <td style="text-align: left;" nowrap="nowrap" colspan="5">
                <asp:Label ID="lblService" CssClass="cssLable" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;" nowrap="nowrap">
                <asp:Label ID="Label5" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Feedback %>"></asp:Label>
            </td>
            <td style="text-align: left;" nowrap="nowrap" colspan="5">
                <asp:Label ID="lblFeedback" CssClass="cssLable" runat="server" Style="word-break: break-all;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
            <td style="text-align: right;">
                <asp:Label ID="Label10" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Unit %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblUnit" CssClass="cssLable" runat="server"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label13" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,PurchasePrice %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblPrice" CssClass="cssLable" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

    <div class="squareboxgradientcaption" style="height: 25px; background-color: silver;">
        <asp:Label ID="Label2" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="<%$ Resources:Resource,ClientDetails %>"></asp:Label>
    </div>
    <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px" class="table table-hover">
        <tr>
            <td style="text-align: right;" nowrap="nowrap">
                <asp:Label ID="Label12" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,ClientCode %>"></asp:Label>
            </td>
            <td style="text-align: left;" nowrap="nowrap">
                <asp:Label ID="lblClientCode" CssClass="cssLable" runat="server"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label17" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,ClientName %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblClientName" CssClass="cssLable" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;" nowrap="nowrap">
                <asp:Label ID="Label23" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Mobile %>"></asp:Label>
            </td>
            <td style="text-align: left;" nowrap="nowrap">
                <asp:Label ID="lblMobile" CssClass="cssLable" runat="server"></asp:Label>
            </td>
            <td style="text-align: right;">
                <asp:Label ID="Label26" CssClass="cssLabelHeader" runat="server" Text="<%$ Resources:Resource,Address %>"></asp:Label>
            </td>
            <td style="text-align: left;">
                <asp:Label ID="lblAddress" CssClass="cssLable" runat="server" Style="word-break: break-all;"></asp:Label>
            </td>

        </tr>

    </table>
    <br />
    <div class="squareboxgradientcaption" style="height: 25px; background-color: silver;">
        <asp:Label ID="Label4" CssClass="cssLabelHeader" Style="font-size: medium;" runat="server" Text="<%$ Resources:Resource,UpdateDetail %>"></asp:Label>
    </div>
    <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px" class="table table-hover">
        <tr>
            <td style="text-align: right;" nowrap="nowrap">
                <asp:Label ID="Label16" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,OrderStatus %>"></asp:Label>
            </td>
            <td style="text-align: left;" nowrap="nowrap">
                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlstatus_SelectedIndexChanged" AutoPostBack="true">
             <%--  <asp:ListItem Text="NEW" Value="NEW"></asp:ListItem>
               <asp:ListItem Text="SCHEDULED" Value="SCHEDULED"></asp:ListItem>--%>
              <%--  <asp:ListItem Text="CANCELLED" Value="CANCELLED"></asp:ListItem>--%>
                    <asp:ListItem Text="ONTHEWAY" Value="ONTHEWAY"></asp:ListItem>
                    <asp:ListItem Text="BREAKDOWN" Value="BREAKDOWN"></asp:ListItem>
                    <asp:ListItem Text="REJECT" Value="REJECT"></asp:ListItem>
                    <asp:ListItem Text="INPROGRESS" Value="INPROGRESS"></asp:ListItem>
                    <asp:ListItem Text="ONHOLD" Value="ONHOLD"></asp:ListItem>
                    <asp:ListItem Text="DONE" Value="DONE"></asp:ListItem>
                    <asp:ListItem Text="CLOSE" Value="CLOSE"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align: right;" runat="server" visible="false" id="tdLabel">
                <asp:Label ID="Label21" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Unit %>" Visible="false"></asp:Label>
                <asp:Label ID="lblText" CssClass="cssLable" runat="server" Text="" ></asp:Label>
            </td>
            <td style="text-align: left;" runat="server" visible="false" id="tdTxt">
                <asp:DropDownList ID="ddlunit" runat="server" CssClass="cssDropDown" Width="150px" Enabled="false" Visible="false">
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList>
                 <asp:TextBox ID="txtTime" CssClass="csstxtbox" runat="server" Style="width: 150px"></asp:TextBox>
                   <asp:TextBox ID="txtReason" CssClass="csstxtbox" runat="server" Style="width: 150px"></asp:TextBox>
            </td>
            <td style="text-align: right;" nowrap="nowrap">
                <asp:Label ID="Label28" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,PurchasePrice %>"></asp:Label>
            </td>
            <td style="text-align: left;" nowrap="nowrap">
                <asp:TextBox ID="txtPrice" CssClass="csstxtbox" runat="server" Style="width: 150px" Enabled="false" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="margin-left:185px" id="divClose" runat="server" visible="false">
         <table >
        <tr>
            <td style="text-align: right;" nowrap="nowrap">
                <asp:Label ID="Label7" CssClass="cssLable" runat="server" Text="Payment Method"></asp:Label>
            </td>
            <td style="text-align: left;" nowrap="nowrap">
                <asp:DropDownList ID="ddlMode" runat="server" CssClass="cssDropDown" Width="150px" OnSelectedIndexChanged="ddlMode_SelectedIndexChanged" AutoPostBack="true">
                     <asp:ListItem Text="CASH" Value="CASH"></asp:ListItem>
                       <asp:ListItem Text="ONLINE" Value="ONLINE"></asp:ListItem>
                
                </asp:DropDownList>
            </td>
             <td style="text-align: right;" runat="server" visible="false" id="tdTRN">
               
                <asp:Label ID="Label9" CssClass="cssLable" runat="server" Text="Transaction ID" ></asp:Label>
            </td>
            <td style="text-align: left;" runat="server" visible="false" id="tdTRN1">
                          <asp:TextBox ID="txtTransactionID" CssClass="csstxtbox" runat="server" Style="width: 150px"></asp:TextBox>
            </td>
            </tr>
             </table>

    </div>
    <br />
            <asp:GridView Width="100%" ID="gvWorkOrderHistory" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="5" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False" OnPageIndexChanging="gvWorkOrderHistory_PageIndexChanging">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                            <ItemTemplate>
                           <asp:Label ID="lblEmployeeNumber" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>">
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeename" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,OrderStatus %>">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderStatus" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("WorkOrderStatus") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ModifiedDate %>">
                            <ItemTemplate>
                                <asp:Label ID="lblModifiedDate" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%#Bind("ModifiedDate") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ProgressCheckInTime %>">
                            <ItemTemplate>
                                <asp:Label ID="lblTime" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("InProgressCheckInTime") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ReasonOnHold %>">
                            <ItemTemplate>
                                <asp:Label ID="lblOnHoldTime" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ReasonForOnHold") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
    <br />
    <center>
        <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:Resource,Update %>" CssClass="cssButton" OnClick="btnUpdate_Click" />
        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:Resource,Back %>" CssClass="cssButton" OnClick="Button1_Click" /></center>
    <asp:Label CssClass="cssLabel" ID="lblerrormsg" runat="server" ForeColor="Red"></asp:Label>
    <asp:HiddenField ID="hfWorkOrderAutoId" runat="server" />
</asp:Content>

