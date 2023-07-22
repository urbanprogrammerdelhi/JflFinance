<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetTagging.aspx.cs" Inherits="AssetManagement_AssetTagging" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script type="text/javascript" language="javascript">
    function OpenSearch(obj) {

        var FrmChild = window.showModalDialog('../Search/SearchEmployeeNumber.aspx', null, 'status:off;center:yes;scroll:no;dialogWidth:860px;help:no;');
        if (FrmChild != null) {
            document.getElementById(obj).value = FrmChild;
        }
        else {
            return false;
        }
    }
</script>
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
                           <asp:Label ID="lblAssetCode" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>' ></asp:Label>
                             </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAssetMaster" runat="server" Value='<%# Bind("AssetAutoId") %>' />
                                <asp:Label ID="LbAssestName" Width="100px" Style="word-break: break-all;" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeMapping %>" Visible="false" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEmployeeMApping" Width="150px" CssClass="cssLabel" runat="server" Text='<%# Bind("MappedEmployeeNo") %>' OnClick="btnEmployeeMApping_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                            <ItemStyle Width="150px" />
                            <FooterStyle Width="150px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,Taging %>" HeaderStyle-ForeColor="White">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnTaging" Width="100px" CssClass="cssLabel" runat="server" Text='<%# Bind("LocationTagging") %>' OnClick="btnTaging_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle CssClass="cssLabelHeader" Width="100px" />
                            <ItemStyle Width="100px" />
                            <FooterStyle Width="100px" />
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
                      


                      </table>
                    
                    
                        <asp:Button ID="btnBackSearchEmp" runat="server" Text="Back" OnClick="btnBackSearchEmp_Click"  CssClass="cssButton"/>
                      <br />
                      <br />
                         
                      <br />
                      <br />
             
                   <asp:HiddenField ID="hfAssetCode" runat="server" />
                      <asp:HiddenField ID="hfAssetCode1" runat="server" />
                         <asp:HiddenField ID="hfAssetAutoId1" runat="server" />
                      <asp:HiddenField ID="hfAssetName1" runat="server" />
                  
            </div>
           <div id="divTaging" runat="server" visible="false">
                      <asp:Panel ID="Panel6" Font-Bold="True" runat="server" Height="160px">
                            <asp:Label ID="lblhead" runat="server" Text="Asset QR Taging" style="color:red ; font-size:larger;" Font-Bold="false"></asp:Label>
                          <br />
                                <table >
                                      <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="lblAsset" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetCode %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label2" runat="server"  Text=" : " >
                                            </asp:Label>
                                       <asp:Label ID="lblAssetCode1" runat="server"   Width="250px"  >
                                            </asp:Label>

                                        </td>

                                           <td rowspan="6">    <asp:PlaceHolder ID="plBarCode" runat="server"  />   </td>
                                    </tr>
                                    
                                      <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label3" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,AssetName %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                              <asp:Label ID="Label4" runat="server"  Text=" : " >
                                            </asp:Label>
                                            <asp:Label ID="lblAssetName1" runat="server"   Width="250px"></asp:Label>

                                        </td>


                                    </tr>
                                    <tr>
                                      <%--  <td style="text-align: right;">
                                            <asp:Label runat="server" ID="lblArea" Text="<%$Resources:Resource,Area %>" CssClass="cssLabel"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList runat="server" ID="ddlAreaID" CssClass="cssDropDown" AutoPostBack="true" Width="350px"
                                                OnSelectedIndexChanged="ddlAreaID_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label1" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Client %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlClientCode" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="250px"
                                                OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                         </tr>
                                     
                                    <tr>
                                        <td style="text-align: right;">
                                            <asp:Label ID="Label16" CssClass="cssLable" runat="server" Text="<%$ Resources:Resource,Asmt %>"></asp:Label>
                                        </td>
                                        <td style="text-align: left;">
                                            <asp:DropDownList ID="ddlAsmtId" runat="server" CssClass="cssDropDown" AutoPostBack="true" Width="250px"
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
                                            <asp:DropDownList ID="ddlPost" runat="server" CssClass="cssDropDown" 
                                                Width="250px">
                                            </asp:DropDownList>
                                        </td>
                                        </tr>
                                    <tr>
                                                                               <td style="text-align: right;">

                                              
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
                          <br />
                         
                                <div >
                                    <asp:Button ID="btnupdate" runat="server" Text="Reallocate Sub Site" CssClass="cssButton"  OnClick="btnupdate_Click"  />
                                     
                                    <asp:Button ID="btnUpdateMapping" runat="server" Text="<%$ Resources:Resource,Update %>" CssClass="cssButton" Visible="false" OnClick="btnUpdateMapping_Click" />
                                      <asp:Button ID="btncancel" runat="server" Text="<%$ Resources:Resource,Cancel %>" CssClass="cssButton"  OnClick="btncancel_Click" Visible="false" />
                                    <asp:Button ID="btnSubmitMapping" runat="server" Text="<%$ Resources:Resource,Submit %>" CssClass="cssButton" OnClick="btnSubmitMapping_Click" Visible="false"/>
                                     <asp:Button ID="QRCode" runat="server" Text="<%$ Resources:Resource,GenerateQRCode %>" CssClass="cssButton"  OnClick="QRCode_Click" Visible="false"/>
                                      <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource,Back %>" CssClass="cssButton"  OnClick="btnBack_Click"/>
                                                              
                                </div>
                             <asp:Label ID="lblMapping"  runat="server" CssClass="csslblErrMsg" style="margin-left:20px"></asp:Label>
                                
                    
                          <asp:HiddenField ID="hfId" runat="server" />
                          <br />
                          <br />
                          <div id="divEmpMapping" runat="server" visible="false">
                            <asp:Label ID="Label7" runat="server" Text="Asset Employee Mapping" style="color:red ; font-size:larger;" Font-Bold="false"></asp:Label>
                        
                            <table >
                                     
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
                            <asp:Button ID="btnSearchEmp" runat="server" Text="Search Employee" OnClick="btnSearchEmp_Click"  CssClass="cssButton" style="margin-left:50px"/>
                       
                            <asp:GridView ID="gvEmployeeList" Width="70%" AllowPaging="True" PageSize="5" CssClass="GridViewStyle" Visible="false"
                    runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                    OnPageIndexChanging="gvEmployeeList_PageIndexChanging">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                      
                         
                           <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                          
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                            </ItemTemplate>
                           
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                            <HeaderStyle Width="100px" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>">
                           
                            <ItemTemplate>
                                <asp:Label ID="lblEmpName" CssClass="cssLable" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                            </ItemTemplate>
                          
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                     
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,DOB %>">
                           
                            <ItemTemplate>
                                <asp:Label ID="lblDOB" CssClass="cssLabel" runat="server" Text='<%# Bind("DateOfBirth") %>'></asp:Label>
                            </ItemTemplate>
                           
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,Gender %>">
                           
                            <ItemTemplate>
                                <asp:Label ID="lblEffectiveFrom" Width="100px" CssClass="cssLable" runat="server"
                                   Text='<%# Bind("Gender") %>'></asp:Label>
                            </ItemTemplate>
                         
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,DateOfJoining %>">
                            <ItemTemplate>
                             
                                <asp:Label ID="lblEffectiveTo" CssClass="cssLable" Width="100px" runat="server"   Text='<%# Bind("DateOfJoining") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                       
                       
                    </Columns>
                </asp:GridView>
                          <br />
                          <br />
                             <asp:GridView ID="gvOwnerAllocate" Width="70%" AllowPaging="True" PageSize="5" CssClass="GridViewStyle" Visible="true"
                    runat="server" CellPadding="1" GridLines="None" AutoGenerateColumns="False" ShowFooter="True"
                    OnPageIndexChanging="gvOwnerAllocate_PageIndexChanging" OnRowCommand="gvOwnerAllocate_RowCommand"
                    OnRowDataBound="gvOwnerAllocate_RowDataBound" OnRowDeleting="gvOwnerAllocate_RowDeleting"
                    OnRowEditing="gvOwnerAllocate_RowEditing" OnRowCancelingEdit="gvOwnerAllocate_RowCancelingEdit"
                    OnRowUpdating="gvOwnerAllocate_RowUpdating">
                    <FooterStyle CssClass="GridViewFooterStyle" />
                    <RowStyle CssClass="GridViewRowStyle" />
                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                    <PagerStyle CssClass="GridViewPagerStyle" />
                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                            <FooterTemplate>
                                <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                    CssClass="cssImgButton" ValidationGroup="AddNewAreaInch" CommandName="AddNewAreaInch"
                                    ImageUrl="../Images/AddNew.gif" />
                                &nbsp;
                                <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                    CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="IBEditAreaIncharge" ToolTip="<%$Resources:Resource, Edit %>"
                                    ImageUrl="~/Images/Edit.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                    CommandName="Edit" />
                                <%--<asp:ImageButton ID="IBDeleteAreaIncharge" ToolTip="<%$Resources:Resource,Delete %>"
                                    ImageUrl="~/Images/Delete.gif" runat="server" CssClass="csslnkButton" CausesValidation="False"
                                    CommandName="Delete" />--%>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="ImgbtnUpdate" runat="server" CssClass="cssImgButton" ValidationGroup="update"
                                    CausesValidation="True" CommandName="Update" ToolTip="<%$ Resources:Resource, Update %>"
                                    ImageUrl="../Images/Save.gif" />
                                <asp:ImageButton ID="ImgbtnCancel" runat="server" CssClass="cssImgButton" CausesValidation="False"
                                    CommandName="Cancel" ToolTip="<%$ Resources:Resource, Cancel %>" ImageUrl="../Images/Cancel.gif" />
                            </EditItemTemplate>
                            <FooterStyle Width="100px" />
                            <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                            <ItemStyle Width="100px" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>">
                            <ItemTemplate>
                                <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetCode %>">
                            <ItemTemplate>
                                  <asp:HiddenField ID="hfAssetAutoId" runat="server" Value='<%# Bind("AssetOwnerMappingAutoId") %>' />
                                <asp:Label ID="lblAssetID" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                  <asp:HiddenField ID="hfAssetAutoId" runat="server" Value='<%# Bind("AssetOwnerMappingAutoId") %>' />
                                <asp:Label ID="lblAssetID" CssClass="cssLabel" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblNewAssetID" runat="server" Text=""></asp:Label>
                                <%-- <asp:DropDownList ID="ddlNewAreaID" Width="100px" CssClass="cssDropDown" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlNewAreaID_SelectedIndexChanged">
                                        </asp:DropDownList>--%>
                            </FooterTemplate>
                            <FooterStyle Width="150px" />
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,AssetName %>">
                            <FooterTemplate>
                                <asp:Label ID="lblNewAssetName" Font-Bold="true" CssClass="cssLabel" runat="server"
                                    Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblAssetName" CssClass="cssLable" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblAssetName" CssClass="cssLable" runat="server" Text='<%# Bind("AssetName") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                            <FooterTemplate>
                                <asp:TextBox ID="txtNewEmployeeNumber" MaxLength="16" CssClass="csstxtbox" runat="server"
                                    Width="100px" Text="" OnTextChanged="txtNewEmployeeNumber_TextChanged"></asp:TextBox>
                                <asp:ImageButton ID="imgSearch" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                    runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" Width="15px" Visible="false" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblEmployeeNumber" CssClass="cssLable" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterStyle Width="150px" />
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" Wrap="False" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>">
                            <FooterTemplate>
                                <asp:Label ID="lblNewEmployeeName" Font-Bold="true" CssClass="cssLabel" runat="server"
                                    Text=""></asp:Label>
                                <asp:HiddenField ID="hdEmpDOJ" runat="server" />        <%--Added by  on 6-Jun-2013--%>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveFrom %>">
                            <FooterTemplate>
                                <asp:TextBox Width="80px" ID="txtEffectiveFrom" CssClass="csstxtbox" runat="server"
                                    Text=""></asp:TextBox>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server"
                                    TargetControlID="txtEffectiveFrom" PopupPosition="TopLeft" />
                                <asp:RequiredFieldValidator ID="reqEffectiveFrom" SetFocusOnError="true" Display="Dynamic"
                                    ErrorMessage="*" runat="server" ValidationGroup="AddNewAreaInch" ControlToValidate="txtEffectiveFrom"></asp:RequiredFieldValidator>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblEffectiveFrom" Width="90px" CssClass="cssLable" runat="server"
                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>

                            <%--    <asp:Label ID="lblEffectiveFrom" Width="90px" CssClass="cssLable" runat="server"
                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>'></asp:Label>--%>
                                                                    
                                <asp:TextBox Width="80px" ID="txtEffectiveFrom" CssClass="csstxtbox" runat="server"
                                    Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveFrom")) %>' Enabled="false"></asp:TextBox>
                               <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender3" Format="dd-MMM-yyyy" runat="server"
                                    TargetControlID="txtEffectiveFrom" PopupPosition="TopLeft" />
                                <asp:RequiredFieldValidator ID="reqEffectiveFrom" SetFocusOnError="true" Display="Dynamic"
                                    ErrorMessage="*" runat="server" ValidationGroup="AddNewAreaInch" ControlToValidate="txtEffectiveFrom"></asp:RequiredFieldValidator>--%>


                            </EditItemTemplate>
                            <FooterStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveTo %>">
                            <FooterTemplate>
                                <asp:Label ID="lblNewEffectiveTo" Font-Bold="true" CssClass="cssLabel" runat="server"
                                    Text=""></asp:Label>
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfAreaInchargeAutoID" runat="server" Value='<%# Bind("AssetOwnerMappingAutoId") %>' />
                                <asp:Label ID="lblEffectiveTo" CssClass="cssLable" Width="90px" runat="server" Text='<%#String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveTo")) %> '></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:HiddenField ID="hfAreaInchargeAutoID" runat="server" Value='<%# Bind("AssetOwnerMappingAutoId") %>' />
                                <asp:TextBox Width="80px" ID="txtEffectiveTo" ValidationGroup="update" CssClass="csstxtbox"
                                    runat="server" Text='<%# String.Format("{0:dd-MMM-yyyy}",Eval("EffectiveTo")) %>'></asp:TextBox>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender2" PopupPosition="Left" Format="dd-MMM-yyyy"
                                    runat="server" TargetControlID="txtEffectiveTo" />
                                                                    <asp:RequiredFieldValidator ID="reqEffectiveTo" ValidationGroup="update" SetFocusOnError="true"
                                    Display="Dynamic" ErrorMessage="*" runat="server" ControlToValidate="txtEffectiveTo"></asp:RequiredFieldValidator>
                                                                </EditItemTemplate>
                            <FooterStyle Width="150px" />
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                       
                       
                    </Columns>
                </asp:GridView>
                              </div>
                             <asp:Label ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                            </asp:Panel>
           </div>
            
          <asp:Button ID="btnPostBack" BackColor="white" BorderWidth="0" runat="server" OnClick="btnPostBack_Click"/>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

