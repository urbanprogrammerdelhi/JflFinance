<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="PrintQR.aspx.cs" Inherits="AssetManagement_PrintQR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
      <br />
          <asp:GridView Width="100%" ID="gvAssetMaster" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="20" CellPadding="1" GridLines="None"
                    AutoGenerateColumns="False"  OnPageIndexChanging="gvAssetMaster_PageIndexChanging" OnRowDataBound="gvAssetMaster_RowDataBound">
                     <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#DBDDF8" />
                            <FooterStyle BackColor="#D3E8F4" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#2E6293" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2E6293" ForeColor="White" />
                            <RowStyle BackColor="#EFF3FB" CssClass="GridViewRowStyle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    <Columns>
                       <%-- <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCode %>">
                            <ItemTemplate>
                           <asp:Label ID="lblAssetCode" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>' ></asp:Label>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                                <asp:Label ID="LbAssestName" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="QR Value">
                            <ItemTemplate>
                                <asp:Label ID="lblQRValue" Width="100px" CssClass="cssLabel" runat="server" Text='<%# Bind("LocationTagging") %>' ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="QR Code">
                            <ItemTemplate>
                              <asp:PlaceHolder ID="plBarCode" runat="server"  /> 
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="50px" Height="50px" />
                            <ItemStyle Width="50px" Height="50px"  />
                            <FooterStyle Width="50px" Height="50px"  />
                        </asp:TemplateField>--%>
                    <%--    <asp:TemplateField HeaderText="QR Code Details">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                             <b>  <asp:Label ID="Label1" Width="110px" Style="word-break: break-all;  " CssClass="cssLabel" runat="server" Text="Asset Code -" ForeColor="RoyalBlue" Font-Bold="true" ></asp:Label></b>
                                        </td>
                                        <td>
                                              <asp:Label ID="lblAssetCode" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>' ForeColor="Black" Font-Bold="true" ></asp:Label>
                                        </td>
                                            <td rowspan="3">  
                                                <asp:Image ID="Image1" runat="server"   ImageUrl = '<%# Eval("QRPath", GetUrl(Eval("QRPath").ToString())) %>' Width="80px" Height="80px" /> 

                                          </td> 
                                    </tr>
                                    <tr>
                                        <td>
                                               <asp:Label ID="Label2" Width="110px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text="Resturant Code-" ForeColor="RoyalBlue" Font-Bold="true"  ></asp:Label>
                                        </td>
                                        <td>
                                             <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                                <asp:Label ID="LbAssestName" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ClientCode") %>' ForeColor="Black" Font-Bold="true" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                               <asp:Label ID="Label4" Width="110px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text="Asset SubCategory-" ForeColor="RoyalBlue" Font-Bold="true" ></asp:Label>
                                        </td>
                                        <td>
                                               <asp:Label ID="lblQRValue" Width="150px" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetSubCategoryName") %>' ForeColor="Black" Font-Bold="true"  ></asp:Label>
                                        </td>
                                    </tr>
                                      <tr>
                                        <td>
                                               <asp:Label ID="Label3" Width="80px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text="QR Value-" ForeColor="RoyalBlue" Font-Bold="true" ></asp:Label>
                                        </td>
                                        <td>
                                               <asp:Label ID="Label5" Width="150px" CssClass="cssLabel" runat="server" Text='<%# Bind("LocationTagging") %>' ForeColor="Black" Font-Bold="true"  ></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                         
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>--%>
                          <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                            FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo1" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="Asset Code" HeaderStyle-ForeColor="White">                                                                   
                                                                    <ItemTemplate>
                                                                     <asp:Label ID="LbAssestCode" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px"  />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                          </asp:TemplateField>
                        <asp:TemplateField HeaderText="Resturant Code" HeaderStyle-ForeColor="White">                                                                   
                                                                    <ItemTemplate>
                                                                     <asp:Label ID="LbResturantCode" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("ClientCode") %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px"  />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                          </asp:TemplateField>

                        <asp:TemplateField HeaderText="Asset Category" HeaderStyle-ForeColor="White">                                                                   
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LbAssestCategory" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCategoryName") %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px"  />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Asset Name" HeaderStyle-ForeColor="White">                                                                   
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LbAssestname" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px"  />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Description" HeaderStyle-ForeColor="White">                                                                   
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="LbAssestdesc" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("Description") %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px"  />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                          </asp:TemplateField>
                        <asp:TemplateField HeaderText="QR Value" HeaderStyle-ForeColor="White">                                                                   
                                                                    <ItemTemplate>
                                                                 <asp:Label ID="LbQRValue" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("LocationTagging") %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px"  />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                          </asp:TemplateField>
                        <asp:TemplateField HeaderText="Capitalized Date" HeaderStyle-ForeColor="White">                                                                   
                                                                    <ItemTemplate>
                                                                     <asp:Label ID="LbAssestdate" Width="200px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("ActiveWEF")) %>' ></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px"  />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                          </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
        <br />
           <asp:Button ID="btnExport" runat="server" CssClass="cssButton" 
                                                    Text="Export to Excel" OnClick="btnExport_Click" />
        </div>
   
</asp:Content>

