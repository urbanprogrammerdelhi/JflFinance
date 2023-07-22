<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetDiscard.aspx.cs" Inherits="AssetManagement_AssetDiscard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
             <div id="DivHeader" runat="server" >
                             
                                    <asp:Button ID="btnViewAll" runat="server" Text="View All Asset" CssClass="cssButton" OnClick="btnViewAll_Click"  />
                                     <asp:Button ID="btnUnderProcess" runat="server" Text="View Under Process Asset" CssClass="cssButton"  OnClick="btnUnderProcess_Click" />
                                   
                                      <asp:Button ID="btnDiscarded" runat="server" Text="View Discarded Asset" CssClass="cssButton" OnClick="btnDiscarded_Click"  />
                                                                 
                                </div>
            <asp:HiddenField ID="hfFlag" runat="server" Value="0" />
           
            <br />
            <div id="divMaster" runat="server">
            <asp:Panel ScrollBars="Auto" ID="PanelAssetMaster" Font-Bold="True" ForeColor="Red" Height="800px" runat="server">
                <asp:GridView Width="50%" ID="gvAssetMaster" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="20" CellPadding="1" GridLines="None"
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
                          <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" Width="50px" CssClass="cssLabel" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="50px" />
                            <ItemStyle Width="50px" />
                            <FooterStyle Width="50px" />
                        </asp:TemplateField>
                         
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCode %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                           <asp:LinkButton ID="lblAssetCode" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>' OnClick="lblAssetCode_Click1" ></asp:LinkButton>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                                <asp:Label ID="LbAssestName" Width="150px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                      
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelNo %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblModelNo" Width="150px" CssClass="cssLabel" runat="server" Text='<%# Bind("ModelNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
               <asp:HiddenField ID="QRValue" runat="server" />
            </asp:Panel>
                 </div>
                  <div id="divAllocate" runat="server" visible="false">
                      <br />
                      <table >
                                      <tr>
                                        <td >
                                            <asp:Label ID="Label5" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,AssetCode %>"></asp:Label>
                                        </td>
                                        <td >
                                              <asp:Label ID="Label6" runat="server"  Text=" : " >
                                            </asp:Label>
                                         <b>   <asp:Label ID="lblAssetCode2" runat="server"  Width="350px" >
                                            </asp:Label></b>

                                        </td>


                                    </tr>
                                    
                                      <tr>
                                        <td >
                                            <asp:Label ID="Label8" CssClass="cssLabel" runat="server" Text="<%$ Resources:Resource,AssetName %>"></asp:Label>
                                        </td>
                                        <td >
                                              <asp:Label ID="Label9" runat="server"  Text=" : " >
                                            </asp:Label>
                                         <b>   <asp:Label ID="lblAssetName2" runat="server"  Width="350px"></asp:Label></b>

                                        </td>


                                    </tr>
                          <tr>
                              <td>
<asp:Label ID="lblSearchByNo" runat="server" Text="Employee No." CssClass="cssLabel"></asp:Label>
                              </td>
                              <td>
                                  <asp:TextBox ID="txtByNo" runat="server" CssClass="csstxtbox"></asp:TextBox>
                              </td>
                          </tr> <tr>
                              <td>
<asp:Label ID="lblSearchbyname" runat="server" Text="Employee Name" CssClass="cssLabel"></asp:Label>
                              </td>
                              <td>
                                  <asp:TextBox ID="txtByName" runat="server" CssClass="csstxtbox"></asp:TextBox>
                              </td>
                          </tr>


                      </table>
                    
                   
                      <br />
                      <br />
         
                   <asp:HiddenField ID="hfAssetCode" runat="server" />
                      <asp:HiddenField ID="hfAssetCode1" runat="server" />
                         <asp:HiddenField ID="hfAssetAutoId1" runat="server" />
                      <asp:HiddenField ID="hfAssetName1" runat="server" />
                   <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
            </div>
           <div id="divTaging" runat="server" visible="false">
                      <asp:Panel ID="Panel6" Font-Bold="True" runat="server" Height="160px"  >                              
                            <table  width="100%" border="0" >
                                      <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblAsset" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCode %>" ></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label2" runat="server"  Text=" : "  >
                                            </asp:Label>
                                       <asp:Label ID="lblAssetCode1" runat="server"   Width="350px"  >
                                            </asp:Label>
                                        </td>
                                    </tr>                                    
                                      <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetName %>" ></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label4" runat="server"  Text=" : " >
                                            </asp:Label>
                                            <asp:Label ID="lblAssetName1" runat="server"   Width="350px" ></asp:Label>
                                        </td>
                                          </tr>
                                       <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label7" CssClass="cssLable" runat="server" Text="Discard Value" ></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label10" runat="server"  Text=" : " >
                                            </asp:Label>
                                           <asp:TextBox ID="txtValue" runat="server"  CssClass="csstxtbox" MaxLength="10" Width="100px"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="rfvValue" ValidationGroup="Save" ControlToValidate="txtValue" Display="Dynamic" runat="server" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                            </tr>
                                 <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="Initiate Date" ></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label11" runat="server"  Text=" : "  >
                                            </asp:Label>
                                                 <asp:TextBox ID="txtInitiate" runat="server"  CssClass="csstxtbox" Width="100px"></asp:TextBox>
                                             <asp:TextBox ID="txtInitiateNew" runat="server"  CssClass="csstxtbox" Width="100px" Visible="false"></asp:TextBox>
                                        </td>
                                    </tr>       
                                       <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label12" CssClass="cssLable" runat="server" Text="Discard Date" Visible="false" ></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label13" runat="server"  Text=" : " Visible="false"  >
                                            </asp:Label>
                                                 <asp:TextBox ID="txtDate" runat="server"  CssClass="csstxtbox" Width="100px" Visible="false"></asp:TextBox>
                                        </td>
                                    </tr>                                  
                                </table>
                              <div style="margin-left: 200px; margin-top: 20px;">                             
                                    <asp:Button ID="btnInitiateDiscard" runat="server" Text="Initiate Discard" CssClass="cssButton" OnClick="btnInitiateDiscard_Click" ValidationGroup="Save" />
                                     <asp:Button ID="btnAuthorizeDiscard" runat="server" Text="Authorize Discard" CssClass="cssButton" OnClick="btnAuthorizeDiscard_Click" Visible="false" />                                   
                                             <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource,Back %>" CssClass="cssButton"  OnClick="btnBack_Click" CausesValidation="false"/>                                                         
                                </div>
                          <br />
                             <asp:Label ID="lblMapping"  runat="server" style="color:red ; font-size:larger;" Font-Bold="false"></asp:Label>
                                
                          <asp:PlaceHolder ID="plBarCode" runat="server"  />
                          <asp:HiddenField ID="hfId" runat="server" />
                            </asp:Panel>
           
                
           </div>
            
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

