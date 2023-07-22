<%@ Page Title="<%$ Resources:Resource, AppTitle %>" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="AssetManufacturer.aspx.cs" 
    Inherits="AssetManagement_AssetManufacturer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
        <ContentTemplate>

            <asp:GridView ID="gvAssetManufacturer" Width="100%" CssClass="GridViewStyle"
                runat="server" AllowPaging="true" CellPadding="3" GridLines="None" DataKeyNames="ManufacturerName"
                AutoGenerateColumns="False" OnRowCancelingEdit="gvAssetManufacturer_RowCancelingEdit"
                OnRowCommand="gvAssetManufacturer_RowCommand" OnRowDataBound="gvAssetManufacturer_RowDataBound"
                OnRowDeleting="gvAssetManufacturer_RowDeleting" OnRowEditing="gvAssetManufacturer_RowEditing" OnRowUpdating="gvAssetManufacturer_RowUpdating"
                ShowFooter="True" OnPageIndexChanging="gvAssetManufacturer_PageIndexChanging" PageSize="20">
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

                    <asp:TemplateField HeaderText="<%$Resources:Resource,EditColName %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="50px" ItemStyle-Width="50px">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImgbtnUpdateAsset" ToolTip="<%$Resources:Resource,Update %>"
                                ImageUrl="~/Images/save.gif" CssClass="csslnkButton" runat="server" CommandName="Update"
                                ValidationGroup="Edit" />
                            <asp:ImageButton ID="ImageButton2Asset" ToolTip="<%$Resources:Resource,Cancel %>"
                                ImageUrl="~/Images/Cancel.gif" CssClass="csslnkButton" runat="server" CausesValidation="False"
                                CommandName="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="IBEditAsset" ToolTip="<%$Resources:Resource,Edit %>" ImageUrl="~/Images/Edit.gif"
                                CssClass="csslnkButton" runat="server" CausesValidation="False" CommandName="Edit" />
                            <asp:ImageButton ID="IBDeleteAsset" ToolTip="<%$Resources:Resource,Delete %>" ImageUrl="~/Images/Delete.gif"
                                runat="server" CssClass="csslnkButton" CausesValidation="False" CommandName="Delete" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ID="lbADD" runat="server" ToolTip="<%$Resources:Resource,Save %>"
                                CssClass="cssImgButton" ValidationGroup="AddNew" CommandName="AddNew" ImageUrl="../Images/AddNew.gif" />
                            <asp:ImageButton ID="lbReset" ToolTip="<%$Resources:Resource,Reset %>" runat="server"
                                CssClass="cssImgButton" CommandName="Reset" CausesValidation="False" ImageUrl="../Images/Reset.gif" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,SerialNumber %>" HeaderStyle-Width="30px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="30px" ItemStyle-Width="30px" HeaderStyle-CssClass="cssLabelHeader">
                        <ItemTemplate>
                            <asp:Label ID="lblSerialNo" CssClass="cssLable" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ManufacturerName %>" HeaderStyle-Width="50px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="50px" ItemStyle-Width="50px">

                        <EditItemTemplate>

                            <asp:HiddenField ID="hfManufacturerAutoID" runat="server" Value='<%# Bind("ManufacturerAutoID") %>' />
                            <asp:Label ID="lblManufacturerName" Width="200px" Style="word-break: break-all" CssClass="cssLable" runat="server" Text='<%# Eval("ManufacturerName") %>'></asp:Label>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID="hfManufacturerAutoID" runat="server" Value='<%# Bind("ManufacturerAutoID") %>' />
                            <asp:Label ID="Label1" Style="word-break: break-all" CssClass="cssLable" Width="180px" runat="server" Text='<%# Bind("ManufacturerName") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewManufacturerName" Width="180px" MaxLength="100" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewManufacturerName"
                                ErrorMessage="" SetFocusOnError="True" ValidationGroup="AddNew" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ManufacturerEmail %>" HeaderStyle-Width="200px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="200px" ItemStyle-Width="200px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtManufacturerEmail" Width="180px" MaxLength="100" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("ManufacturerEmail") %>'></asp:TextBox>
                             <asp:RegularExpressionValidator ID="REVEmailUpdate" runat="server" ForeColor="Red" ControlToValidate="txtManufacturerEmail" ValidationGroup="Edit" ErrorMessage="*" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" Width="200px" Style="word-break: break-all" CssClass="cssLable" runat="server" Text='<%# Bind("ManufacturerEmail") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewManufacturerEmail" Width="180px" MaxLength="100" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVEmail" runat="server" ForeColor="Red" ControlToValidate="txtNewManufacturerEmail" ValidationGroup="AddNew" ErrorMessage="*" SetFocusOnError="true" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ManufacturerPhone %>" HeaderStyle-Width="80px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="80px" ItemStyle-Width="80px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtManufacturerPhone" Width="80px" MaxLength="15" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("ManufacturerPhone") %>'></asp:TextBox>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" Width="80px" Style="word-break: break-all" CssClass="cssLable" runat="server" Text='<%# Bind("ManufacturerPhone") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewManufacturerPhone" Width="80px" MaxLength="15" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server"></asp:TextBox>

                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource,ManufacturerAddress %>" HeaderStyle-Width="400px" HeaderStyle-ForeColor="White"
                        FooterStyle-Width="400px" ItemStyle-Width="400px">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtManufacturerAddress" Width="400px" MaxLength="100" ValidationGroup="Edit"
                                CssClass="csstxtbox" runat="server" Text='<%# Bind("ManufacturerAddress") %>' TextMode="MultiLine"></asp:TextBox>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label4" Width="400px" Style="word-break: break-all" CssClass="cssLable" runat="server" Text='<%# Bind("ManufacturerAddress") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNewManufacturerAddress" Width="400px" MaxLength="100" ValidationGroup="AddNew"
                                CssClass="csstxtbox" runat="server" TextMode="MultiLine"></asp:TextBox>

                        </FooterTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <asp:Label EnableViewState="false" ID="lblErrorMsg" runat="server" CssClass="csslblErrMsg"></asp:Label>
        </ContentTemplate>
    </Ajax:UpdatePanel>

</asp:Content>


