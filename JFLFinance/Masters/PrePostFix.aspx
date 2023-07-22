<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrePostFix.aspx.cs" Inherits="Masters_PrePostFix" Title="<%$ Resources:Resource, AppTitle %>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" BorderWidth="1px" runat="server" Width="1040px" Height="550px"
                                        ScrollBars="Auto" CssClass="ScrollBar">
                                        <asp:GridView ID="gvPrePostFix" Width="1020px" CssClass="GridViewStyle" PageSize="12"
                                            runat="server" AllowPaging="false" CellPadding="1" GridLines="None" AutoGenerateColumns="False"
                                            OnRowDataBound="gvPrePostFix_RowDataBound">
                                            
                                          
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
                                                        <asp:Label ID="lblgvhdrSeqField" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, AutoUpdatePostFix%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvSeqField" CssClass="cssLable" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SeqField").ToString()%>'></asp:Label>
                                                    </ItemTemplate>
                                                  
                                                   
                                                </asp:TemplateField>
                                                <asp:TemplateField    HeaderStyle-Width="100px"
                                                  ItemStyle-Width="100px">
                                                  <HeaderTemplate>
                                                        <asp:Label ID="lblIsAutoUpdatePostFix" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, AutoUpdatePostFix%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkIsAutoUpdatePostFix" ValidationGroup="AddNew" CssClass="csstxtbox"  Checked='<%# Bind("IsAutoUpdatePostFix") %>'  runat="server"  />&nbsp;
                                                    </ItemTemplate>
                                                   
                                                    <HeaderStyle CssClass="cssLabelHeader" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px"  ItemStyle-Width="150px" >
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvPrefixStr" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, PrefixText%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                       <asp:TextBox Width="150px" ID="txtPrefixStr" CssClass="csstxtbox" Text='<%# Bind("PrefixStr") %>' MaxLength="10" runat="server" onchange="validatePrePostFixText(this)"></asp:TextBox>
                                                     </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px"  ItemStyle-Width="130px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvPostfixStr" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, PostFixText%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                     <asp:TextBox Width="150px" ID="txtPostfixStr" CssClass="csstxtbox"  Text='<%# Bind("PostfixStr") %>' MaxLength="10" runat="server" onchange="validatePrePostFixText(this)"></asp:TextBox>
                                                      </ItemTemplate> 
                                                   
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="150px" FooterStyle-Width="150px" ItemStyle-Width="150px">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblgvRunningSeq" CssClass="cssLabelHeader" runat="server" Text="<% $ Resources:Resource, RunningSequence%>"></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                      <asp:TextBox Width="150px" ID="txtRunningSeq" CssClass="csstxtbox"  Text='<%# Bind("RunningSeq") %>' runat="server" MaxLength="16" onchange="validateRunningSeq(this)"></asp:TextBox>
                                                     <asp:HiddenField ID="hdnInsertUpdateStatus" runat="server" Value='<%# Bind("InsertUpdateStatus") %>' />
                                                         </ItemTemplate>
                                                  
                                                   
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
        function validatePrePostFixText(txtValue) {

            var sValue = txtValue.value;
            var pattern = /^[0-9a-zA-Z()\_\-~\[\]\'\/:]+$/;
            if (!pattern.test(sValue)) {
                alert("Only -/_:~()[] characters are allowed");
                txtValue.value = "";
                return false;
            }
        }

        function validateRunningSeq(txtValue) {

            var sValue = txtValue.value;

            if (isNaN(sValue)) {
                alert("Only Numeric Values are allowed");
                txtValue.value = "0";
                return false;
            }
        }

        
        
</script>
</asp:Content>

