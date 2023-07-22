<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true"
    CodeFile="ComponentMaster.aspx.cs" Inherits="Masters_ComponentMaster" Title="<%$ Resources:Resource, AppTitle %>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1">
        <ContentTemplate>
            <asp:GridView Width="100%" ID="gvComponentMaster" UseAccessibleHeader="true" CssClass="GridViewStyle"
                runat="server" ShowFooter="True" AllowPaging="True" PageSize="15" CellPadding="1"
                GridLines="None" AutoGenerateColumns="False" AllowSorting="false" OnRowCommand="gvComponentMaster_RowCommand"
                OnRowDataBound="gvComponentMaster_RowDataBound" OnPageIndexChanging="gvComponentMaster_PageIndexChanging"
                OnRowCancelingEdit="gvComponentMaster_RowCancelingEdit" OnRowDeleting="gvComponentMaster_RowDeleting"
                OnRowEditing="gvComponentMaster_RowEditing" OnRowUpdating="gvComponentMaster_RowUpdating" DataKeyNames="CompanyCode,ComponentCode"
                OnSelectedIndexChanged="gvComponentMaster_SelectedIndexChanged" onmousemove="TableResize_OnMouseMove(this);"
                onmouseup="TableResize_OnMouseUp(this);" onmousedown="TableResize_OnMouseDown(this);"
                OnRowCreated="gvComponentMaster_RowCreated">
                <FooterStyle CssClass="GridViewFooterStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                <PagerStyle CssClass="GridViewPagerStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <Columns>
                    <%--<asp:TemplateField>
                        <HeaderStyle Width="25px" />
                        <ItemStyle Width="25px" BackColor="White" />
                        <HeaderTemplate>
                        </HeaderTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,SerialNumber %>" HeaderStyle-Width="50px"
                        FooterStyle-Width="50px" ItemStyle-Width="50px">
                        <%--<HeaderTemplate>
                            <asp:Image ID="imgTab" onclick="javascript:Toggle(this);" runat="server" ImageUrl="~/Images/Minus.gif" ToolTip="Collapse" />
                        </HeaderTemplate>--%>
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLabel" runat="server"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ComponentCode %>" HeaderStyle-Width="200px"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <EditItemTemplate>
                            <asp:Label ID="lblComponentCode" CssClass="cssLabel" runat="server" Text='<%# Eval("ComponentCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewComponentCode" CssClass="csstxtbox" Width="85%" MaxLength="16"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewComponentCode"
                                ErrorMessage="" ValidationGroup="AddNew" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" CssClass="cssLabel" runat="server" Text='<%# Bind("ComponentCode") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ComponentDesc %>" HeaderStyle-Width="600px"
                        FooterStyle-Width="600px" ItemStyle-Width="600px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtComponentDesc" CssClass="csstxtbox" Width="550px" MaxLength="50"
                                runat="server" Text='<%# Bind("ComponentDesc") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtComponentDesc"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="Edit">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewComponentDesc" CssClass="csstxtbox" Width="550px" MaxLength="50"
                                ValidationGroup="AddNew" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewComponentDesc"
                                ErrorMessage="" ValidationGroup="AddNew" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" CssClass="cssLabel" runat="server" Text='<%# Bind("ComponentDesc") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle CssClass="cssLabelHeader" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:Resource,EditColName %>">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdateTran" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            &nbsp;
                            <asp:ImageButton ID="ImageButton2Tran" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            &nbsp;
                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEditTran" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" ValidationGroup="Edit" runat="server" CausesValidation="False"
                                CommandName="Edit" />
                            &nbsp;
                            <asp:ImageButton ID="IBDeleteTran" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterStyle Width="100px" />
                        <HeaderStyle Width="100px" CssClass="cssLabelHeader" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Code" Visible="false">
                        <EditItemTemplate>
                            <asp:Label ID="lblCompanyCode" runat="server" Text='<%# Eval("CompanyCode") %>'></asp:Label>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblNewCompanyCode" runat="server" Text="Label" Visible="True"></asp:Label>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCompanyCode" runat="server" Text='<%# Bind("CompanyCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>
    <script type="text/javascript">
        var Grid = null;
        var UpperBound = 0;
        var LowerBound = 1;
        var CollapseImage = '~/Images/Minus.gif';
        var ExpandImage = '~/Images/Plus.gif';
        var IsExpanded = true;   
        var Rows = null;
        var n = 1;
        var TimeSpan = 25;
                    
        window.onload = function()
        {
            Grid = document.getElementById('<%= this.gvComponentMaster.ClientID %>');
            UpperBound = parseInt('<%= this.gvComponentMaster.Rows.Count %>');
            Rows = Grid.getElementsByTagName('tr');
        }
                    
        function Toggle(Image)
        {
            ToggleImage(Image);
            ToggleRows();  
        }    
                    
        function ToggleImage(Image)
        {
            if(IsExpanded)
            {
                Image.src = ExpandImage;
                Image.title = 'Expand';
                Grid.rules = 'none';
                n = LowerBound;
                            
                IsExpanded = false;
            }
            else
            {
                Image.src = CollapseImage;
                Image.title = 'Collapse';
                Grid.rules = 'cols';
                n = UpperBound;
                            
                IsExpanded = true;
            }
        }
                    
        function ToggleRows()
        {
            if (n < LowerBound || n > UpperBound)  return;
                                        
            Rows[n].style.display = Rows[n].style.display == '' ? 'none' : '';
            if(IsExpanded) n--; else n++;
            setTimeout("ToggleRows()",TimeSpan);
        }
    </script>
</asp:Content>
