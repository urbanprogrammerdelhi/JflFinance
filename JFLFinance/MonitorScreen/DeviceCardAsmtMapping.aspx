
<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="DeviceCardAsmtMapping.aspx.cs" Inherits="MonitorScreen_DeviceCardAsmtMapping" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <table style="border:0px; width:50%; margin:5px;" >
        <tr>
       <td align="right">
   <asp:Label ID="lblSearch" Text="<%$ Resources:Resource,Search %>" CssClass="cssLabel" runat="server"> </asp:Label> 
             </td>
     <td align="left">
    <asp:DropDownList ID="ddlselect" CssClass="cssDropDown" runat="server">
        <asp:ListItem Text="<%$ Resources:Resource,ClientCode %>" Value="ClientCode"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:Resource,Asmtid %>" Value="Asmtid"></asp:ListItem>
        <asp:ListItem Text="<%$ Resources:Resource,AsmtCardNo %>" Value="AsmtCardNo"></asp:ListItem>
    </asp:DropDownList>
          </td>
      <td align="left">
     <asp:TextBox ID="txtSearch" Width="200px" MaxLength="35" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
           </td>
                 <td align="left">
              <asp:Button ID="btnsearch" runat="server" Text="<%$ Resources:Resource,Search %>" CssClass="cssButton"  OnClick="btnsearch_Click"/>

                 </td>
                 <td align="left">
         <asp:Button ID="btnViewAll" runat="server" Text="<%$ Resources:Resource,ViewAll %>" CssClass="cssButton" OnClick="btnViewAll_Click"/>
                 </td>
             </tr>
         </table>
  
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>
           
            <asp:GridView ID="gvDeviceCardAsmtMapping" Width="100%" CssClass="GridViewStyle" PageSize="15"
                runat="server" AllowPaging="true" CellPadding="1" GridLines="None" DataKeyNames="ClientCode"
                AutoGenerateColumns="False" OnRowCancelingEdit="gvDeviceCardAsmtMapping_RowCancelingEdit"
                OnRowCommand="gvDeviceCardAsmtMapping_RowCommand" OnRowDataBound="gvDeviceCardAsmtMapping_RowDataBound"
                OnRowDeleting="gvDeviceCardAsmtMapping_RowDeleting" OnRowEditing="gvDeviceCardAsmtMapping_RowEditing" OnRowUpdating="gvDeviceCardAsmtMapping_RowUpdating"
                ShowFooter="True" OnPageIndexChanging="gvDeviceCardAsmtMapping_PageIndexChanging" OnSelectedIndexChanged="gvDeviceCardAsmtMapping_SelectedIndexChanged">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                   
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ClientCode %>">
                                                                    <EditItemTemplate>
                                                                     
                                                                         <asp:Label ID="lbleditClientCode" CssClass="cssLabel" runat="server" Text='<%# Bind("clientcode") %>'></asp:Label>  
                                                                   
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlClientCode" AutoPostBack="true"  OnSelectedIndexChanged="ddlClientCode_SelectedIndexChanged"  CssClass="cssDropDown" Width="85%" runat="server">
                                                                        </asp:DropDownList>   
                                                                       
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                           <asp:HiddenField ID="hfCardAsmtMappingAutoId" runat="server" Value='<%# Bind("CardAsmtMappingAutoId") %>' />
                                                                         <asp:Label ID="lblClientCode" CssClass="cssLabel" runat="server" Text='<%# Bind("clientcode") %>'></asp:Label>  
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                       </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,Asmtid %>">
                                                                    <EditItemTemplate>
                                                                       <asp:Label ID="lbleditAsmtid" CssClass="cssLabel" runat="server" Text='<%# Bind("AsmtId") %>'></asp:Label>   
                                                                      
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:DropDownList ID="ddlAsmtid" CssClass="cssDropDown" Width="85%" runat="server">
                                                                        </asp:DropDownList>   
                                                                       
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                         <asp:Label ID="lblAsmtid" CssClass="cssLabel" runat="server" Text='<%# Bind("AsmtId") %>'></asp:Label>  
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="cssLabelHeader" Width="200px" />
                                                                    <ItemStyle Width="200px" />
                                                                    <FooterStyle Width="200px" />
                       </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,AsmtCardNo %>" HeaderStyle-Width="100px"
                        FooterStyle-Width="600px" ItemStyle-Width="600px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAsmtCardNo" Width="200px" MaxLength="35" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("AsmtCardNumber") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAsmtCardNo"
                                ValidationGroup="Edit" ErrorMessage="" SetFocusOnError="True" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCardNo" CssClass="cssLable" runat="server" Text='<%# Bind("AsmtCardNumber") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewAsmtCardNo" Width="200px" MaxLength="35" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewAsmtCardNo"
                                ValidationGroup="AddNew" ErrorMessage="" SetFocusOnError="True" Display="Dynamic" ForeColor="Red" >*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EffectiveFromDate %>">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEffectiveFromDate" CssClass="csstxtbox" Width="80px" runat="server" Text='<%#String.Format("{0:d-MMM-yyyy}",Eval("EffectiveFromDate")) %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvtxtEffectiveFromDate1" runat="server" ControlToValidate="txtEffectiveFromDate" SetFocusOnError="true" ForeColor="Red" ErrorMessage="*" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                                                                  <asp:ImageButton ID="imgEditFromDate" runat="server" CausesValidation="true" ImageUrl="~/Images/pdate.gif" Style="vertical-align: middle" />
                                                                <AjaxToolKit:CalendarExtender ID="CalendarExtenderFromDate" runat="server" Format="dd-MMM-yyyy" PopupButtonID="imgEditFromDate" PopupPosition="TopRight" TargetControlID="txtEffectiveFromDate" />
 
                                    </EditItemTemplate>
                                    <FooterTemplate>
                                        <asp:TextBox ID="txtEffectiveFromDate" CssClass="csstxtbox" runat="server" Width="80px" ></asp:TextBox>
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
                                        <asp:TextBox ID="txtEffectiveToDate" CssClass="csstxtbox" runat="server" Width="80px"></asp:TextBox>
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
                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="100px"
                        FooterStyle-Width="100px" ItemStyle-Width="100px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdateLang" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImageButton2Lang" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEditLang" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="IBDeleteLang" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
    </ContentTemplate>
</Ajax:UpdatePanel>   
</asp:Content>

