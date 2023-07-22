<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetDiscardList.aspx.cs" Inherits="AssetManagement_AssetDiscardList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
       <table align="center" width="100%" border="0" cellspacing="0px" cellpadding="0px">
             <tr>                      
             
                  <td style="text-align: right;">
                    <asp:Label ID="Label2" CssClass="cssLable" Style="width: 100px;" runat="server" Text="Asset Code"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtAssetCode" MaxLength="30" Width="120px" CssClass="csstxtbox" 
                        runat="server" ></asp:TextBox>
                   </td>
                 
                  <td style="text-align: right;">
                    <asp:Label ID="Label1" CssClass="cssLable" Style="width: 100px;" runat="server" Text="Asset Name"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtAssetName" MaxLength="30" Width="120px" CssClass="csstxtbox" 
                        runat="server" ></asp:TextBox>
                   </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblActivewef" CssClass="cssLable" Style="width: 100px;" runat="server" Text="From Date"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtDate" MaxLength="50" Width="120px" CssClass="csstxtbox" 
                        runat="server" ></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtDate" PopupButtonID="ImageButton1" Enabled="True"></AjaxToolKit:CalendarExtender>
                   
                </td>
                  <td style="text-align: right;">
                    <asp:Label ID="Label3" CssClass="cssLable" Style="width: 100px;" runat="server" Text="To Date"></asp:Label>
                </td>
                  <td style="text-align: left;">
                    <asp:TextBox ID="txtToDate" MaxLength="50" Width="120px" CssClass="csstxtbox" 
                        runat="server" ></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" Style="vertical-align: middle" runat="server" ImageUrl="~/Images/pdate.gif" Enabled="true"></asp:ImageButton>
                    <AjaxToolKit:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                        TargetControlID="txtToDate" PopupButtonID="ImageButton2" Enabled="True"></AjaxToolKit:CalendarExtender>
                </td>             
              <td>
                  <asp:Button ID="BtnView" runat="server" CssClass="cssButton" OnClick="BtnView_Click" Text="Search" />&nbsp;&nbsp;
                  <asp:Button ID="btnViewAll" runat="server" CssClass="cssButton" OnClick="btnViewAll_Click" Text="View All" />
              </td>
            </tr>
               </table>
    <br />
             <asp:GridView Width="90%" ID="gvAssetDiscardList" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="15" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False"  OnPageIndexChanging="gvAssetDiscardList_PageIndexChanging">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCode %>">
                            <ItemTemplate>
                           <asp:Label ID="lblAssetCode" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>'  ></asp:Label>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>">
                            <ItemTemplate>
                               
                                <asp:Label ID="LbAssestName" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelNo %>">
                            <ItemTemplate>
                                <asp:Label ID="lblModelNo" Width="150px" CssClass="cssLabel" Style="word-break: break-all;"  runat="server" Text='<%# Bind("ModelNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelName %>">
                            <ItemTemplate>
                                <asp:Label ID="lblModelName" Width="150px" CssClass="cssLabel" Style="word-break: break-all;"  runat="server" Text='<%# Bind("ModelName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNo %>">
                            <ItemTemplate>
                           <asp:Label ID="lblSerialNo" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("SerialNo") %>'  ></asp:Label>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Description %>">
                            <ItemTemplate>
                            
                                <asp:Label ID="lblDescription" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,DiscardValue %>">
                            <ItemTemplate>
                                <asp:Label ID="lblDiscardValue" Width="150px" CssClass="cssLabel" runat="server" Style="word-break: break-all;"  Text='<%# Bind("DiscardValue") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,InitiateDate %>">
                            <ItemTemplate>
                                <asp:Label ID="lblInitaiteDate" Width="150px" CssClass="cssLabel" runat="server" Style="word-break: break-all;"  Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("InitaiteDate")) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="<%$ Resources:Resource,DiscardDate %>">
                            <ItemTemplate>
                                <asp:Label ID="lblDiscardDate" Width="150px" CssClass="cssLabel" Style="word-break: break-all;"  runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("DiscardDate")) %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,DiscardBy %>">
                            <ItemTemplate>
                                <asp:Label ID="lblDiscardedBy" Width="150px" CssClass="cssLabel" Style="word-break: break-all;"  runat="server" Text='<%# Bind("DiscardedBy") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
     <asp:Button ID="btnExport" runat="server" CssClass="cssButton" ToolTip="<%$ Resources:Resource, ExporttoExcel %>"
                                                    Text=" <%$ Resources:Resource, ExporttoExcel %>" OnClick="btnExport_Click"/>
</asp:Content>

