<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ScheduleContextMenu.aspx.cs" Inherits="Masters_ScheduleContextMenu" Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                        <td>
                        <table>
                        <tr>
                        <td>
                         <asp:Label ID="lblLocation" CssClass="cssLable" runat="server" Text="<%$Resources:Resource,Location %>"></asp:Label>
                                               
                        </td>
                        <td>
                        <asp:DropDownList ID="ddlLocation" CssClass="cssDropDown" Width="250px" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DdlLocation_SelectedIndexChanged">
                                                </asp:DropDownList>
                        </td>
                        </tr>
                        </table>
                        </td>
                        </tr>
                        <tr>
                        <td></td>
                          <td></td>
                        </tr>
                            <tr>
                                <td >
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="820px" Height="450px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvScheduleContextMenu" Width="800px" CssClass="GridViewStyle" PageSize="12"
                                            runat="server" AllowPaging="false" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                            OnRowDataBound="gvScheduleContextMenu_RowDataBound">
                                            
                                          
                                            <FooterStyle CssClass="GridViewFooterStyle" />
                                            <RowStyle CssClass="GridViewRowStyle" />
                                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                            <PagerStyle CssClass="GridViewPagerStyle" />
                                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                                                     ItemStyle-Width="50px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvhdrMenuItemCode" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, MenuItemCode%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvMenuItemCode" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemCode").ToString()%>'></asp:Label>
                                                    <asp:HiddenField runat="server" ID="hdnMenuAutoID" Value='<%# Bind("MenuAutoID") %>'  />
                                                    </ItemTemplate>
                                                  
                                                   
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                    
                                                        <asp:Label ID="lblgvhdrMenuItemName" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource,MenuItemName %>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvMenuItemName" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MenuItemName").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                  
                                                   
                                                </asp:TemplateField>
                                                <asp:TemplateField    HeaderStyle-Width="100px"
                                                  ItemStyle-Width="100px">
                                                  <HeaderTemplate>
                                                        <asp:Label ID="lblIsActive" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, IsActive%>"></asp:Label>
                                                     <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick="CheckAll(this);" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkIsActive" ValidationGroup="AddNew" CssClass="csstxtbox"  Checked='<%# Bind("IsActive") %>'  runat="server"  />&nbsp;
                                                    </ItemTemplate>
                                                   
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField    HeaderStyle-Width="80px"
                                                  ItemStyle-Width="80px">
                                                  <HeaderTemplate>
                                                        <asp:Label ID="lblAttendanceType" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, AttendanceType%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                         <asp:DropDownList Width="130px" ID="ddlAttendanceType" CssClass="cssDropDown" runat="server" >
                                                         <asp:ListItem Value="ALL" Text="<% $ Resources:Resource, All%>"></asp:ListItem>
                                                         <asp:ListItem Value="ACT" Text="<% $ Resources:Resource, Actual%>"></asp:ListItem>
                                                         <asp:ListItem Value="SCH" Text="<% $ Resources:Resource, Schedule%>"></asp:ListItem>
                                                        </asp:DropDownList>   
                                                        <asp:HiddenField runat="server" ID="hdnAttendanceType" Value='<%# Bind("AttendanceType") %>'  />
                                                        </ItemTemplate>
                                                        
                                                   
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                              
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField runat="server" ID="hfglobalRole" Value="" />
                                    <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                
                                  <td align="center">
                                                <asp:Button ID="btnSubmit" runat="server" Text="<%$Resources:Resource,Submit %>" ValidationGroup="vgClient"
                                                    CssClass="cssButton" TabIndex="15" OnClick="btnSubmit_Click" />
                                          
                                        </td>
                                
                            </tr>
                        </table>
                    </ContentTemplate>
                </Ajax:UpdatePanel>
            </td>
        </tr>
    </table>
    <script type="text/javascript">

        function CheckAll(Checkbox) {
         
            var gvScheduleContextMenu = document.getElementById("<%=gvScheduleContextMenu.ClientID %>");
            for (i = 1; i < gvScheduleContextMenu.rows.length; i++) {
                gvScheduleContextMenu.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
         
        }

        
</script>
</asp:Content>

