<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="DeviceCardEmpMapping.aspx.cs" Inherits="MonitorScreen_DeviceCardEmpMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
     <table style="border:0px; width:50%; margin:5px;" >
             <tr>
                 <td align="right">
                   <asp:Label ID="lblSearch" Text="<%$ Resources:Resource,Search %>" runat="server" CssClass="cssLabel"></asp:Label>
                 </td>
                 <td align="left">
                     <asp:DropDownList ID="ddlselect" runat="server" CssClass="cssDropDown">
                         <asp:ListItem Text="<%$ Resources:Resource,EmployeeNumber %>" Value="EmployeeNumber" ></asp:ListItem>
                          <asp:ListItem Text="<%$ Resources:Resource,EmployeeName %>" Value="EmployeeName" ></asp:ListItem>
                          <asp:ListItem Text="<%$ Resources:Resource,EmployeeCardNumber %>" Value="EmployeeCardNumber" ></asp:ListItem>

                     </asp:DropDownList>
                 </td>
                 <td align="left">
                     <asp:TextBox ID="txtsearch" runat="server" Width="250px" MaxLength="50"  CssClass="csstxtbox" ></asp:TextBox>
                 </td>
                 <td align="left">
                     <asp:Button ID="btnsearch" runat="server" Text="<%$ Resources:Resource,Search %>" CssClass="cssButton"  OnClick="btnsearch_Click"/>

                 </td>
                 <td align="left">
                <asp:Button ID="btnViewAll" runat="server" Text="<%$ Resources:Resource,ViewAll %>" CssClass="cssButton" OnClick="btnViewAll_Click"   />
                 </td>
             </tr>
         </table>
     <asp:Panel ID="Panel1" Font-Bold="True" ScrollBars="Auto" ForeColor="Red" 
                       Height="420px" runat="server">
        
                        <asp:GridView Width="100%" ID="gvDeviceCardEmpMapping" CssClass="GridViewStyle" runat="server" ShowFooter="True" AllowPaging="True" PageSize="10" CellPadding="1" GridLines="None"
                            AutoGenerateColumns="False" OnRowDataBound="gvDeviceCardEmpMapping_RowDataBound" OnRowCommand="gvDeviceCardEmpMapping_RowCommand"
                            OnRowEditing="gvDeviceCardEmpMapping_OnRowEditing" OnPageIndexChanging="gvDeviceCardEmpMapping_PageIndexChanging"
                            OnRowUpdating="gvDeviceCardEmpMapping_RowUpdating" OnRowCancelingEdit="gvDeviceCardEmpMapping_OnRowCancelingEdit" OnRowDeleting="gvDeviceCardEmpMapping_RowDeleting">
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                            ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" ValidationGroup="Edit" CommandName="Update" />
                                        <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                            ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                            CommandName="Cancel" />
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                            CssClass="cssImgButton" CommandName="AddNew" ValidationGroup="Insert" ImageUrl="../Images/AddNew.gif" />
                                        &nbsp;
                                        <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                            CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                            CssClass="csslnkButton" runat="server" CausesValidation="False"
                                            CommandName="Edit" />
                                        <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                            runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                                    </ItemTemplate>
                                    <FooterStyle Width="100px" />
                                    <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                                    <ItemStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeNumber %>">
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="HFCardEmpMappingAutoId" runat="server" Value='<%# Bind("CardEmpMappingAutoId") %>' />
                                        <asp:Label ID="txtEmployeeNumber"  CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>

                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:HiddenField ID="hfCardEmpMappingAutoId" runat="server" Value="0" />
                                        <asp:TextBox ID="txtEmployeeNumber" Width="100px" CssClass="csstxtbox" runat="server" TabIndex="1" AutoPostBack="true" MaxLength="16" OnTextChanged="txtEmployeeNumber_TextChanged"></asp:TextBox>
                                        <asp:ImageButton ID="imgSearchEmp" AlternateText="<%$ Resources:Resource,SearchEmployee %>"
                                            runat="server" ImageUrl="~/Images/icosearch.gif" ToolTip="" Width="15px" OnClick="imgSearchEmp_Click" />
                                        <asp:RequiredFieldValidator ID="rfvtxtEmployeeNumber" runat="server" ControlToValidate="txtEmployeeNumber" ForeColor="Red" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HFCardEmpMappingAutoId" runat="server" Value='<%# Bind("CardEmpMappingAutoId") %>' />
                                        <asp:Label ID="lblEmployeeNumber" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                    <ItemStyle Width="200px" />
                                    <FooterStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeName %>">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblEmployeeNameEdit" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                           <asp:TextBox ID="txtEmployeeName" CssClass="cssLabel" runat="server"  Enabled="false" ReadOnly="true" ></asp:TextBox>
                                      
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeName" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>

                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                    <ItemStyle Width="200px" />
                                    <FooterStyle Width="200px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EmployeeCardNumber %>">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEmployeeCardNumber" CssClass="csstxtbox" runat="server" MaxLength="35" Text='<%# Bind("EmployeeCardNumber") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtEmployeeCardNumber1" runat="server" ControlToValidate="txtEmployeeCardNumber" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>

                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtEmployeeCardNumber" CssClass="csstxtbox" runat="server" MaxLength="35" TabIndex="2"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="rfvtxtEmployeeCardNumber" runat="server" ControlToValidate="txtEmployeeCardNumber" ForeColor="Red" SetFocusOnError="true" ErrorMessage="*" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                       
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployeeCardNumber" CssClass="cssLabel" runat="server" Text='<%# Bind("EmployeeCardNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                    <ItemStyle Width="200px" />
                                    <FooterStyle Width="200px" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveFromDate %>">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEffectiveFromDate" CssClass="csstxtbox" Width="80px" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveFromDate")) %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtEffectiveFromDate1" runat="server" ControlToValidate="txtEffectiveFromDate" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                                  <asp:ImageButton ID="imgEditFromDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgEditFromDate" PopupPosition="TopRight" TargetControlID="txtEffectiveFromDate" />
 
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtEffectiveFromDate" CssClass="csstxtbox" runat="server" Width="80px" TabIndex="3" ></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="rfvtxtEffectiveFromDate" runat="server" ControlToValidate="txtEffectiveFromDate" ForeColor="Red" SetFocusOnError="true" ErrorMessage="*" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                                <asp:ImageButton ID="imgNewFromDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderNewFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgNewFromDate" PopupPosition="TopRight" TargetControlID="txtEffectiveFromDate" />
 
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEffectiveFromDate" CssClass="cssLabel" runat="server"  Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveFromDate")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                    <ItemStyle Width="150px" />
                                    <FooterStyle Width="150px" />
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveToDate %>">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEffectiveToDate" Width="80px" CssClass="csstxtbox" runat="server"  Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveToDate")) %>'></asp:TextBox>
 <asp:ImageButton ID="imgEditToDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderToDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgEditToDate" PopupPosition="TopRight" TargetControlID="txtEffectiveToDate" />
                                           </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtEffectiveToDate" CssClass="csstxtbox" runat="server" Width="80px" TabIndex="4"></asp:TextBox>
                                        <asp:ImageButton ID="imgNewToDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderNewToDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgNewToDate" PopupPosition="TopRight" TargetControlID="txtEffectiveToDate" />
 
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEffectiveToDate" CssClass="cssLabel" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveToDate")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="cssLabelHeader" Width="150px" />
                                    <ItemStyle Width="150px" />
                                    <FooterStyle Width="150px" />
                                </asp:TemplateField>
                                
                              </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Label ID="lblDeviceCardEmpMapping" EnableViewState="False" runat="server" CssClass="csslblErrMsg"></asp:Label>
    
</asp:Content>

