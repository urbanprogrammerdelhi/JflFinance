<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetTransfer.aspx.cs" Inherits="AssetManagement_AssetTransfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
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
                          <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="50px" ItemStyle-Width="50px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
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
                       <%--  <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNo %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" Width="150px" CssClass="cssLabel" runat="server" Text='<%# Bind("SerialNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>--%>
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
                      <asp:Panel ID="Panel6" Font-Bold="True" runat="server" Height="160px">
                                 <asp:Label ID="lblhead" runat="server" Text="Asset Current Mapping" style="color:red ; font-size:larger;" Font-Bold="false"></asp:Label>
                                <table align="left" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                                  
                                      <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblAsset" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCode %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label2" runat="server"  Text=" : " >
                                            </asp:Label>
                                       <asp:Label ID="lblAssetCode1" runat="server"   Width="350px"  >
                                            </asp:Label>

                                        </td>


                                    </tr>
                                    
                                      <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetName %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label4" runat="server"  Text=" : " >
                                            </asp:Label>
                                            <asp:Label ID="lblAssetName1" runat="server"   Width="350px"></asp:Label>

                                        </td>


                                    </tr>
                                       <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label7" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Client %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label10" runat="server"  Text=" : " >
                                            </asp:Label>
                                            <asp:Label ID="lblClientName1" runat="server"   Width="350px"></asp:Label>

                                        </td>


                                    </tr>
                                       <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label12" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Asmt %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label13" runat="server"  Text=" : " >
                                            </asp:Label>
                                            <asp:Label ID="lblAsmt1" runat="server"   Width="350px"></asp:Label>

                                        </td>


                                    </tr>
                                       <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label15" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SubSite %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label18" runat="server"  Text=" : " >
                                            </asp:Label>
                                            <asp:Label ID="lblSubSite1" runat="server"   Width="350px"></asp:Label>

                                        </td>


                                    </tr>
                               
                                 <%--   <tr>

                                        <td style="text-align: right;" nowrap="nowrap">
                                            <asp:Label ID="Label18" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Remark %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" nowrap="nowrap">
                                            <asp:TextBox ID="txtRemark" CssClass="csstxtbox" runat="server" MaxLength="100" Width="350px"></asp:TextBox>

                                        </td>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label19" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Usage %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:TextBox ID="txtUsage" CssClass="csstxtbox" runat="server" MaxLength="50" Width="350px"></asp:TextBox>
                                    </tr>--%>

                                </table>
                          <br />
                            <asp:Label ID="Label11" runat="server" Text="Initiate Asset Transfer" style="color:red ; font-size:larger;" Font-Bold="false"></asp:Label>
                                <table align="left" width="100%" border="0" cellspacing="0px" cellpadding="0px">
                                         <tr>
                                    
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Client %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="350px"
                                                OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                         </tr>
                                     
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label16" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Asmt %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlAsmtId" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="350px"
                                                OnSelectedIndexChanged="ddlAsmtId_SelectedIndexChanged">
                                            </asp:DropDownList>

                                        </td>


                                    </tr>
                                       <br />
                                    <tr>
                                        
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label17" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,SubSite %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlPost" runat="server" CssClass="cssDropDown" AutoPostBack="true"
                                                Width="350px">
                                            </asp:DropDownList>
                                        </td>
                                        </tr>
                                    <tr>
                                                                               <td style="text-align: right;">

                                              
                                        </td>
                                    </tr>
                                    </table>
                          <br />
                         
                                <div style="margin-left: 200px; margin-top: 30px;">
                                    <br />
                                    <asp:Button ID="btnupdate" runat="server" Text="Initiate Transfer" CssClass="cssButton"  OnClick="btnupdate_Click"  />
                                     
                                    <asp:Button ID="btnUpdateMapping" runat="server" Text="Transfered" CssClass="cssButton" Visible="false" OnClick="btnUpdateMapping_Click" />
                                   
                                      <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource,Back %>" CssClass="cssButton"  OnClick="btnBack_Click"/>
                                                                 
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

